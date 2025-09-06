using UnityEngine;
using System.Collections.Generic;

public class LootCratePool : MonoBehaviour
{
    [SerializeField] private GameObject lootCratePrefab;
    private readonly Queue<GameObject> _pool = new Queue<GameObject>();

    public GameObject Get()
    {
        if (_pool.Count == 0)
            AddNew();

        return _pool.Dequeue();
    }

    public void Return(GameObject crate)
    {
        crate.SetActive(false);
        _pool.Enqueue(crate);
    }

    public void Prewarm(int count)
    {
        for (int i = 0; i < count; i++)
            AddNew();
    }

    private void AddNew()
    {
        GameObject crate = Instantiate(lootCratePrefab);
        crate.SetActive(false);
        _pool.Enqueue(crate);
    }
}
