using UnityEngine;

public class Obstacle : MonoBehaviour
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
