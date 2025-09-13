using UnityEngine;

public class DynamicArch : ArchBase
{
    private int _soldierCountChange = 0;

    private void Start()
    {
        _soldierCountChange = Random.Range(-RoundDuration._roundDuration, RoundDuration._roundDuration);
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
        if (other.TryGetComponent<SoldierCollision>(out SoldierCollision soldier))
        {
            OnPass();
        }
    }
}
