using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private float _destroyTimerMin, _destroyTimerMax;

    private bool _isColorChanged = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!_isColorChanged && collision.gameObject.CompareTag("Platform") )
        {
            ChangeColor();
            DestroyWithDelay();          
        }
    }
    private void ChangeColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
        _isColorChanged = true;
    }

    private void DestroyWithDelay()
    {
        float destroyTimer = Random.Range(_destroyTimerMin, _destroyTimerMax - 1);
        Destroy(gameObject, destroyTimer);
    }
}
