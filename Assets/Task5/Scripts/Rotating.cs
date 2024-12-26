using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
