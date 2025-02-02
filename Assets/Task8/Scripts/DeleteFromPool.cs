using UnityEngine;

public class DeleteFromPool : MonoBehaviour
{
    private CubePool _cubePool;
    private void Start()
    {
        _cubePool = GameObject.FindGameObjectWithTag("CubePool").GetComponent<CubePool>();
    }
    public void OnDestroy()
    {
        if (_cubePool != null)
        {
            _cubePool.DeletePoolObject(gameObject);
        }
    }
}
