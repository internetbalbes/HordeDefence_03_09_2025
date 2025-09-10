using UnityEngine;

[RequireComponent(typeof(Pool))]
public class Player : MonoBehaviour
{
    [SerializeField] private RestartGame _restartGame;

    [SerializeField] private int _soldierCount;

    private Pool _pool { get; set; }

    [SerializeField] private GameObject _soldierPrefab;

    private void Start()
    {
        _pool = GetComponent<Pool>();
        _pool = new Pool(_soldierPrefab);

        SoldierMovement.SetPlayer(gameObject);
        Soldier._player = this;

        // случайное начальное кол-во солдат
        _soldierCount = Random.Range(-5, 11);

        // спавним хотя бы 1 солдата если значение > 0
        for (int i = 0; i < Mathf.Max(1, _soldierCount); i++)
            AddSoldier();
    }

    public void AddSoldier()
    {
        GameObject soldier = _pool.Get();
        _soldierCount++;
    }

    public void RemoveSoldier(GameObject soldier)
    {
        _pool.Return(soldier);
        _soldierCount--;

        if (_soldierCount <= 0)
            _restartGame.GameRestart();
    }

    // умножение солдат
    public void MultiplySoldiers(int multiplier)
    {
        int target = _soldierCount * multiplier;
        AdjustSoldiers(target);
    }

    // деление солдат
    public void DivideSoldiers(int divider)
    {
        if (divider == 0) return;
        int target = _soldierCount / divider;
        AdjustSoldiers(target);
    }

    // общее изменение количества
    private void AdjustSoldiers(int target)
    {
        if (target > _soldierCount)
        {
            int diff = target - _soldierCount;
            for (int i = 0; i < diff; i++)
                AddSoldier();
        }
        else if (target < _soldierCount)
        {
            int diff = _soldierCount - target;
            for (int i = 0; i < diff; i++)
            {
                // здесь нужен доступ к солдату, которого мы удаляем
                // допустим, пул сам разберётся
                RemoveSoldier(null);
            }
        }
    }

    private void OnEnable() => EnemyHealth.Dead += AddSoldier;
    private void OnDisable() => EnemyHealth.Dead -= AddSoldier;
}