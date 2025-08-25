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
    //[SerializeField] private Image _radiusSprite;
    [SerializeField] private Slider _abilityBar;
    [SerializeField] private TextMeshProUGUI _abilityTimeText;
    [SerializeField] private Health _health;

    private bool isActive = false;
    private bool isOnCooldown = false;
    private float timer = 0f;


    private void Start()
    {
        //_radiusSprite.gameObject.SetActive(false);

        _abilityBar.maxValue = _abilityDuration;

        _abilityBar.value = _abilityDuration;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isActive && !isOnCooldown)
        {
            StartCoroutine(ActivateAbility());
        }
        /*
        if (isActive)
        {
            _abilityBar.value = timer;
            _abilityTimeText.text = $"Drain: {timer:F1}s";
        }
        else if (isOnCooldown)
        {
            _abilityBar.value = timer;
            _abilityTimeText.text = $"Cooldown: {timer:F1}s";
        }
        else
        {
            _abilityBar.value = _abilityDuration;
            _abilityTimeText.text = "Ready!";
        }
        */
    }

    private IEnumerator ActivateAbility()
    {
        isActive = true;

        timer = _abilityDuration;

        //_radiusSprite.gameObject.SetActive(true);

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            Collider2D enemyCol = Physics2D.OverlapCircle(transform.position, _abilityRadius, _enemyLayer);
         
            if (enemyCol != null)
            {
                Health health = enemyCol.GetComponent<Health>();

                if (health != null)
                {
                    float drain = _drainAmountPerSecond * Time.deltaTime;

                    health.ApplyDamage(drain);

                    _health.Heal(drain);
                }
            }

            yield return null;
        }

        //_radiusSprite.gameObject.SetActive(false);

        isActive = false;

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        isOnCooldown = true;

        timer = 0f;

        _abilityBar.maxValue = _cooldownDuration;

        while (timer < _cooldownDuration)
        {
            timer += Time.deltaTime;

            yield return null;
        }

        isOnCooldown = false;

        _abilityBar.maxValue = _abilityDuration;

        _abilityBar.value = _abilityDuration;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _abilityRadius);
    }
}