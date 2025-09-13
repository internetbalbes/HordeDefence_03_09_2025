using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObstacleList))]
[RequireComponent(typeof(Timer))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    internal UnityAction<GameObject> ObstacleSpawned;
    
    private ObstacleList _obstacleList;

    private void Start()
    {
        _obstacleList = GetComponent<ObstacleList>();
    }

    private void Spawn()
    {
        float totalChance = 0f;

        foreach (var obstacle in _obstacleList.Obstacles)
        {
            totalChance += obstacle.SpawnChance;
        }

        float randomPoint = Random.value * totalChance;

        foreach (var obstacle in _obstacleList.Obstacles)
        {
            if (randomPoint < obstacle.SpawnChance)
            {
                GameObject newObstacle = Instantiate(obstacle.Prefab, new Vector3(0,0,0), Quaternion.identity);
                ObstacleSpawned?.Invoke(newObstacle);
                return;
            }

            else
            {
                randomPoint -= obstacle.SpawnChance;
            }
        }
    }

    private void OnEnable()
    {
        _timer.Updated += Spawn;
    }

    private void OnDisable()
    {
        _timer.Updated -= Spawn;
    }
}
