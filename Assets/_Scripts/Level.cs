using UnityEngine;
using UnityEngine.Pool;

public class Level : MonoBehaviour
{
    private IObjectPool<Level> levelPool;

    public void SetPool(IObjectPool<Level> pool)
    {
        levelPool = pool;
    }
    private void OnTriggerEnter(Collider other)
    {
        levelPool.Get();
    }
    private void OnTriggerExit(Collider other)
    {
        levelPool.Release(this);
    }
}
