using UnityEngine;

[RequireComponent(typeof(Spawner))]

public class TransformSpawnedObstacle : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private readonly Vector2 _xRange = new Vector2(-2f, 2f);

    private void OnEnable()
    {
        _spawner.ObstacleSpawned += TransformObstacle;
    }

    private void OnDisable()
    {
        _spawner.ObstacleSpawned -= TransformObstacle;
    }

    private void TransformObstacle(GameObject obstacle)
    {
        obstacle.transform.position = new Vector3(Random.Range(_xRange.x, _xRange.y), transform.position.y + 0.5f, transform.position.z);
    }
}
