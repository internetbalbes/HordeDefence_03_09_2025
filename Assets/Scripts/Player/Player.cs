using UnityEngine;

public class Player : MonoBehaviour
{
    public SoldierPool soldierPool;

    private void Start()
    {
        AddSoldier();
    }

    private void OnEnable() => Health.OnDied += HandlePawnKilled;
    private void OnDisable() => Health.OnDied -= HandlePawnKilled;

    private void HandlePawnKilled(GameObject pawn)
    {
        AddSoldier();
    }

    private void AddSoldier()
    {
        GameObject soldier = soldierPool.Dequeue();

        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-2f, 2f), -0.25f, Random.Range(-2f, 2f));
        soldier.transform.position = spawnPos;

        soldier.GetComponent<SoldierMovement>().player = transform;
        soldier.SetActive(true);
    }

    public void RemoveSoldier(GameObject soldier)
    {   
        soldier.SetActive(false);
        soldier.transform.parent = null;
        soldierPool.Enqueue(soldier);
    }
}
