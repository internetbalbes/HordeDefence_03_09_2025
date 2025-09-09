using UnityEngine;

public class Poolable : MonoBehaviour
{
    protected Pool _pool;

    public void Initialize(Pool pool)
    {
        _pool = pool;
    }

    public Pool GetPool()
    {
        return _pool;
    }
}
