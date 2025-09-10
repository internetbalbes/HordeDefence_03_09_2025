using UnityEngine;

public class ObstacleSpawnTransform : MonoBehaviour
{
    private readonly Vector2 _xRange = new Vector2(-2.5f, 2.5f);

    private void OnEnable()
    {
        Spawner.Spawned += OnObstacleSpawned;
    }
    private void OnDisable()
    {
        Spawner.Spawned -= OnObstacleSpawned;
    }

    private void OnObstacleSpawned(GameObject obstacle)
    {
        obstacle.transform.position = new Vector3(
            Random.Range(_xRange.x, _xRange.y),
            transform.position.y,
            transform.position.z
        );
    }
}
