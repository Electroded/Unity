using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float forceMagnitude = 10f;
    private int numObjects;

    public void Explode()
    {
        print("Explode");

        InstantiateObjectsAroundTarget();

        Destroy(gameObject);
    }
    private void InstantiateObjectsAroundTarget()
    {
        numObjects = Random.Range(2, 7);
        for (int i = 0; i < numObjects; i++)
        {
            print(numObjects);
            Vector3 randomPoint = Random.insideUnitCircle * radius;
            Vector3 spawnPosition = transform.position + new Vector3(randomPoint.x, 0f, randomPoint.y);

            GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
            
            if (instance.TryGetComponent<Rigidbody>(out var rb))
            {
                Vector3 direction = (instance.transform.position - transform.position).normalized;

                rb.AddForce(direction * forceMagnitude, ForceMode.Impulse);

                instance.transform.localScale = Vector3.one / 2;

                instance.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

                if (instance.GetComponent<Renderer>())
                {
                    Renderer renderer = instance.GetComponent<Renderer>();
                    renderer.material.color = Random.ColorHSV();
                }
            }
            else
            {
                Debug.LogError("Prefab must have a Rigidbody component!");
            }
            numObjects /= 2;
        }
    }
}
