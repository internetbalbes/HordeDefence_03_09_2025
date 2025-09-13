using UnityEngine;
using System.Collections.Generic;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _soldierPrefab;

    [SerializeField] private int _soldierCount = 0;

    private List<GameObject> _soldiers = new List<GameObject>();

    [SerializeField] private Run _run; 

    public event System.Action AllSoldiersDead;

    private void Start()
    {
        _soldierPrefab.GetComponent<PlayerFollowing>().SetPlayer(gameObject);
    }

    public void ChangeSoldierCount(int change)
    {
        if (change > 0)
        {
            for (int i = 0; i < change; i++)
                AddSoldier();
        }
        else if (change < 0)
        {
            for (int i = 0; i < Mathf.Abs(change); i++)
                RemoveSoldier();
        }
    }

    [ContextMenu("AddSoldier")]
    internal void AddSoldier()
    {
        _soldierCount++;
        GameObject soldier = Instantiate(_soldierPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        _soldiers.Add(soldier);
    }

    internal void RemoveAtSoldier(GameObject soldier)
    {
        _soldiers.Remove(soldier);
        _soldierCount--;
        Destroy(soldier);

        if (_soldierCount == 0)
            AllSoldiersDead?.Invoke();
    }

    internal void RemoveSoldier()
    {
        GameObject soldier = _soldiers[0];
        _soldiers.RemoveAt(0); 
        _soldierCount--;
        Destroy(soldier);

        if (_soldierCount == 0)
            AllSoldiersDead?.Invoke();
    }

    public void Multiply(int multiplier)
    {
        int newCount = _soldierCount * multiplier;
        int change = newCount - _soldierCount;
        ChangeSoldierCount(change);
    }

    public void Divide(int divisor)
    {
        int newCount = Mathf.FloorToInt((float)_soldierCount / divisor);
        int change = newCount - _soldierCount;
        ChangeSoldierCount(change);
    }

    private void OnEnable()
    {
        EnemyHealth.Dead += AddSoldier;
        _run.Started += AddSoldier;
    }
    private void OnDisable()
    {
        EnemyHealth.Dead -= AddSoldier;
        _run.Started -= AddSoldier;
    }

}
