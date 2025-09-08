using UnityEngine;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;

    private Queue<GameObject> _pool = new Queue<GameObject>();

    public GameObject Get()
    {

        if (_pool.Count == 0)
            Add();
        GameObject obj = _pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }

    private void Add()
    {
        GameObject obj = Instantiate(_objectPrefab);
        obj.SetActive(false);
        _pool.Enqueue(obj);
    }
}
