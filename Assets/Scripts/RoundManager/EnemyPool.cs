using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject pawnPrefab;
    private readonly Queue<GameObject> _pool = new Queue<GameObject>();

    public GameObject Get()
    {
        if (_pool.Count == 0)
            AddNew();

        return _pool.Dequeue();
    }

    public void Return(GameObject pawn)
    {
        pawn.SetActive(false);
        _pool.Enqueue(pawn);
    }

    public void Prewarm(int count)
    {
        for (int i = 0; i < count; i++)
            AddNew();
    }

    private void AddNew()
    {
        GameObject pawn = Instantiate(pawnPrefab);
        pawn.SetActive(false);
        _pool.Enqueue(pawn);
    }
}
