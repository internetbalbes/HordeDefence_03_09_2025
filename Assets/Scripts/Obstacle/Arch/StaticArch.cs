using UnityEngine;

public class StaticArch : ArchBase
{
    private int value = 2;

    private void Start()
    {
        InitDisplay();
    }

    public override void OnPass()
    {
        _soldierSpawner.Divide(value);
        Destroy(gameObject);
    }

    protected override void InitDisplay()
    {
        NotifyValueChanged("/", value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SoldierCollision>(out SoldierCollision soldier))
        {
            OnPass();
        }
    }
}
