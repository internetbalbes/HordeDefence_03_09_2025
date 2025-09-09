using System.Collections.Generic;
using UnityEngine;

public class CrateGunPacker : MonoBehaviour
{
    [SerializeField] private List<Gun> _guns;

    private TimeredSpawner _timeredSpawner => GetComponent<TimeredSpawner>();

    private void OnEnable()
    {
        _timeredSpawner.ThisSpawned += OnThisSpawned;
    }

    private void OnDisable()
    {
        _timeredSpawner.ThisSpawned -= OnThisSpawned;
    }

    private void OnThisSpawned(GameObject obstacle)
    {
        obstacle.GetComponent<Crate>().Gun(_guns[Random.Range(0,_guns.Count)]);
    }
}
