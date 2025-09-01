using UnityEngine;

public class MovementInput : MonoBehaviour
{
    [SerializeField] private MovementFB _movementFB;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movementFB.Jump();
        }
    }
}
