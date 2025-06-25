using UnityEngine;

public class PlayerAttack : Attack
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }
}
