using UnityEngine;

public class DynamicArch : ArchBase
{
    private int _soldierCountChange = 0;
    private bool _isPassed = false; // флаг, чтобы столкновение срабатывало только один раз

    private void Start()
    {
        _soldierCountChange = Random.Range(-RoundDuration.Instance.Duration, RoundDuration.Instance.Duration);
        InitDisplay();
    }

    public override void OnPass()
    {
        _soldierSpawner.ChangeSoldierCount(_soldierCountChange);
        Destroy(gameObject);
    }

    public void OnRaycastHit()
    {
        _soldierCountChange++;
        InitDisplay();
    }

    protected override void InitDisplay()
    {
        NotifyValueChanged(_soldierCountChange >= 0 ? "+" : "-", Mathf.Abs(_soldierCountChange));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isPassed) return;

        if (other.TryGetComponent<SoldierCollision>(out SoldierCollision soldier))
        {
            _isPassed = true;
            GetComponent<Collider>().enabled = false;
            OnPass();
        }
    }
}
