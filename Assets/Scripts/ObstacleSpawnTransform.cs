using UnityEngine;

public class ObstacleSpawnTransform : MonoBehaviour
{
    private readonly Vector2 _xRange = new Vector2(-3, 3);

    private void OnEnable() => Spawner.ObstacleSpawned += OnObstacleSpawned;
    private void OnDisable() => Spawner.ObstacleSpawned -= OnObstacleSpawned;

    private void OnObstacleSpawned(GameObject obstacle)
    {
        obstacle.transform.position = new Vector3(
            Random.Range(_xRange.x, _xRange.y),
            transform.position.y,
            transform.position.z
        );
    }
}
