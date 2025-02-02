using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private float destroyTimerMin, destroyTimerMax;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") && collision.gameObject.TryGetComponent<Renderer>(out var renderer))
        {
            renderer.material.color = Color.red;
            float destroyTimer = Random.Range(destroyTimerMin, destroyTimerMax-1);
            Destroy(collision.gameObject, destroyTimer);
        }
    }
}