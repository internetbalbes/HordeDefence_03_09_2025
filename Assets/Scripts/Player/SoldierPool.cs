using System.Collections.Generic;
using UnityEngine;

public class SoldierPool : MonoBehaviour
{
    private Queue<GameObject> _soldiers = new Queue<GameObject>();

    public GameObject soldierPrefab;

    public void Enqueue(GameObject soldier)
    {   
        soldier.SetActive(false);
        _soldiers.Enqueue(soldier);
    }

    public GameObject Dequeue()
    {
        GameObject soldier;

        if (_soldiers.Count == 0)
            soldier = Instantiate(soldierPrefab);
        else
            soldier = _soldiers.Dequeue();
        return soldier;
    }
}
