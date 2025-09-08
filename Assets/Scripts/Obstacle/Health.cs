using UnityEngine;

public class Health : MonoBehaviour
{
    private int _healthPoints = 2;
    
    public void TakeDamage(int damage)
    {
        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            OnHealthPointsZero();
        }
    }

    protected virtual void OnHealthPointsZero() { }
}