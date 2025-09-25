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

    private void Spawn(GameObject obstacle)
    {
        GameObject newObstacle = Instantiate(obstacle, new Vector3(0, 0, 0), Quaternion.identity);
        ObstacleSpawned?.Invoke(newObstacle);
    }

    private GameObject GetRandomObstacle()
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
                return obstacle.Prefab;
            }
            else
            {
                randomPoint -= obstacle.SpawnChance;
            }
        }

        return null;
    }


    private void SpawnRandomObstacle()
    {
        Spawn(GetRandomObstacle());
    }
    

    private void OnEnable()
    {
        _timer.Updated += SpawnRandomObstacle;
    }

    private void OnDisable()
    {
        _timer.Updated -= SpawnRandomObstacle;
    }
}
