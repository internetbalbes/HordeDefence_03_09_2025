using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Pool _pool;

    private void Start()
    {
        AddSoldier();
    }

    private void AddSoldier(GameObject enemy = null)
    {
        GameObject soldier = _pool.Get();

        Vector3 spawnPos = transform.position + new Vector3(Random.Range(-2f, 2f), -0.25f, Random.Range(-2f, 2f));
        soldier.transform.position = spawnPos;

        soldier.GetComponent<SoldierMovement>().player = transform;
        soldier.SetActive(true);
    }

    public void RemoveSoldier(GameObject soldier)
    {
        soldier.SetActive(false);
        _pool.Return(soldier);
    }

    private void OnEnable()
    {
        EnemyHealth.Dead += AddSoldier;
    }

    private void OnDisable()
    {
        EnemyHealth.Dead += AddSoldier;
    }
}
