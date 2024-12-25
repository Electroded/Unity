using UnityEngine;

public class Scaling : MonoBehaviour
{
    [SerializeField] private float scaleSpeed;

    private void FixedUpdate()
    {
        transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
    }
}
