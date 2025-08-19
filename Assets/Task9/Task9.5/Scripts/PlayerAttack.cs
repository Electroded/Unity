using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Attack _attack;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _attack.PerformAttack();
        }
    }
}
