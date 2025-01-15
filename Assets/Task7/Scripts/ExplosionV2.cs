using UnityEngine;

public class ExplosionV2 : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private float explosionForce = 10f;
    [SerializeField] private float minSizeRadiusFactor = 1.5f;
    [SerializeField] private float minSizeForceFactor = 1.2f;

    public float upwardModifier = 0.2f;

    //private bool hasExploded = false;

    [SerializeField] private GameObject prefab;
    [SerializeField] private float radius = 5f;
    //[SerializeField] private float forceMagnitude = 10f;
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

                ExplodeV2();

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
    private void ExplodeV2()
    {
        float effectiveRadius = explosionRadius;
        float effectiveForce = explosionForce;

        if (transform.localScale.x < 0.5f)
        {
            effectiveRadius *= minSizeRadiusFactor;
            effectiveForce *= minSizeForceFactor;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, effectiveRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null && collider.gameObject != gameObject)
            {
                Vector3 direction = (collider.transform.position - transform.position);
                float distance = direction.magnitude;
                direction.Normalize();

                float forceMagnitude = Mathf.Lerp(effectiveForce, 0, distance / effectiveRadius);

                direction.y += upwardModifier;

                rb.AddForce(direction * forceMagnitude, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        float effectiveRadius = explosionRadius;
        if (transform.localScale.x < 0.5f)
        {
            effectiveRadius *= minSizeRadiusFactor;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, effectiveRadius);
    }
}