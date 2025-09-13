using UnityEditor;
using UnityEngine;

[System.Serializable]
public class ObstaclePrefab
{
    [SerializeField] private GameObject prefab;
    [SerializeField, Range(0, 100)] private int _spawnChance;
    internal int SpawnChance => _spawnChance;
    internal GameObject Prefab => prefab;
}
