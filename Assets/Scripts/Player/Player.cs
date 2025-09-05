using UnityEngine;

public class Player : MonoBehaviour
{
    public SoldierPool soldierPool;

    private void Start()
    {
        AddSoldier();
    }

    private void AddSoldier()
    {
        GameObject soldier = soldierPool.Dequeue();
        soldier.GetComponent<SoldierMovement>().player = gameObject.transform;
        soldier.SetActive(true);
    }

    public void RemoveSoldier(GameObject soldier)
    {   
        soldier.SetActive(false);
        soldier.transform.parent = null;
        soldierPool.Enqueue(soldier);
    }
}
