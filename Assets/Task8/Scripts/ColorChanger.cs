using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public bool _isColorChanged = false;

    public void ChangeColor()
    {
         _renderer = GetComponent<Renderer>();
         _renderer.material.color = Color.red;
         _isColorChanged = true;
    }
}