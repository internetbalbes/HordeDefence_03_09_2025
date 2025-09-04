using UnityEngine;
using UnityEngine.Events;

public class LootCrate : MonoBehaviour
{
    private int _healthPoints = 10000;

    public UnityAction<int> HealthPointsChanged;

    private void Start() => HealthPointsChanged?.Invoke(_healthPoints);
    
    public void TakeDamage(int damage)
    {
        _healthPoints -= damage;
        HealthPointsChanged?.Invoke(_healthPoints);

        if (_healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
