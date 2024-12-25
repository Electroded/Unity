using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, speed);
    }
}
