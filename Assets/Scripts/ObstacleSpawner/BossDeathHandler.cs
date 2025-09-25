using UnityEngine;

public class BossDeathHandler : MonoBehaviour
{
    [SerializeField] private Timer _spawnerTimer;

    private void OnEnable()
    {
        BossHealth.Dead += OnDead;
    }

    private void OnDisable()
    {
        BossHealth.Dead -= OnDead;
    }

    private void OnDead()
    {
        _spawnerTimer.IsRunning(true);
    }
}
