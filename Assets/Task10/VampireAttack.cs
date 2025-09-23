using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class VampireAttack : MonoBehaviour
{
    [SerializeField] private float _abilityRadius = 3f;
    [SerializeField] private float _drainAmountPerSecond = 10f;
    [SerializeField] private float _abilityDuration = 6f;
    [SerializeField] private float _cooldownDuration = 8f;

    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Slider _abilityBar;
    [SerializeField] private TextMeshProUGUI _abilityTimeText;
    [SerializeField] private HealthController _healthController;

    private bool _isActive = false;
    private bool _isOnCooldown = false;
    private float _timer = 0f;

    private void Start()
    {
        _abilityBar.maxValue = _abilityDuration;

        _abilityBar.value = _abilityDuration;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isActive && !_isOnCooldown)
        {
            StartCoroutine(ActivateAbility());
        }

        print(_isActive);
    }

    private IEnumerator ActivateAbility()
    {
        _isActive = true;

        _timer = _abilityDuration;

        while (_timer > 0)
        {
            _timer -= Time.deltaTime;

            Collider2D enemyCol = Physics2D.OverlapCircle(transform.position, _abilityRadius, _enemyLayer);
         
            if (enemyCol != null)
            {
                HealthController healthController = enemyCol.GetComponent<HealthController>();

                if (healthController != null)
                {
                    float drain = _drainAmountPerSecond * Time.deltaTime;

                    healthController.TakeDamage(drain);

                    _healthController.Heal(drain);
                }
            }
            yield return null;
        }
        _isActive = false;

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        _isOnCooldown = true;

        _timer = 0f;

        _abilityBar.maxValue = _cooldownDuration;

        while (_timer < _cooldownDuration)
        {
            _timer += Time.deltaTime;

            _abilityBar.value = _timer;

            yield return null;
        }
        _isOnCooldown = false;

        _abilityBar.maxValue = _abilityDuration;

        _abilityBar.value = _abilityDuration;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _abilityRadius);
    }
}