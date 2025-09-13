using System.Collections.Generic;
using UnityEngine;

public class ObstacleList : MonoBehaviour
{
    [SerializeField] private List<ObstaclePrefab> _obstacles;

    internal List<ObstaclePrefab> Obstacles => _obstacles;
}
