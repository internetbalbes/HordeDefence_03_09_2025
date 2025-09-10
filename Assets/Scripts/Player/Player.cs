using UnityEngine;

[RequireComponent(typeof(Pool))]

public class Player : MonoBehaviour
{
    private Pool _pool { get; set; }

    [SerializeField] private GameObject _soldierPrefab;

    private void Start()
    {
        _pool = GetComponent<Pool>();
        _pool = new Pool(_soldierPrefab);

        SoldierMovement.SetPlayer(gameObject);

        AddSoldier();
    }

    public void AddSoldier()
    {
        GameObject soldier = _pool.Get();
        soldier.transform.position = transform.position;
    }

    public void RemoveSoldier(GameObject soldier)
    {
        _pool.Return(soldier);
    }

    private void OnEnable()
    {
        EnemyHealth.Dead += AddSoldier;
    }

    private void OnDisable()
    {
        EnemyHealth.Dead -= AddSoldier;
    }
}
