using System.Collections.Generic;
using UnityEngine;

public class CrateGunPacker : MonoBehaviour
{
    [SerializeField] private List<Gun> _guns;

    private void OnEnable()
    {
        Crate.CrateCreated += OnCrateCreated;
    }

    private void OnDisable()
    {
        Crate.CrateCreated -= OnCrateCreated;
    }

    private void OnCrateCreated(Crate crate)
    {
        crate.Gun(_guns[Random.Range(0,_guns.Count)]);
    }
}
