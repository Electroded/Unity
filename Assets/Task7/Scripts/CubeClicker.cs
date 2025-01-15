using UnityEngine;

public class CubeClicker : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<Explosion>())
                {
                    Explosion explosion = hit.collider.gameObject.GetComponent<Explosion>();
                    explosion.Explode();
                }
                else if (hit.collider.gameObject.GetComponent<ExplosionV2>())
                {
                    ExplosionV2 explosionV2 = hit.collider.gameObject.GetComponent<ExplosionV2>();
                    explosionV2.Explode();
                }
            }
        }
    }
}
