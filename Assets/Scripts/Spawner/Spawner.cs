using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Pool))]

public class Spawner : MonoBehaviour
{
    private void Start()
    {
        _pool = GetComponent<Pool>();
        _pool = new Pool(_obstaclePrefab);
    }

    public static UnityAction<GameObject> Spawned; // for tranform position using obstaleSpawnerTransform.position
    public UnityAction<GameObject> ThisSpawned;


    [SerializeField] private GameObject _obstaclePrefab;

    protected Pool _pool { get; set; }

    protected void Spawn()
    {
        GameObject obstacle = _pool.Get();
        Spawned?.Invoke(obstacle);
        ThisSpawned?.Invoke(obstacle);
    }
}
