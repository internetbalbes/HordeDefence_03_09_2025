using UnityEngine;

public class StaticArch : ArchBase
{
    private bool isMultiplier = true;
    private int value = 2;

    private void Start()
    {
        isMultiplier = Random.Range(0, 2) == 0;
        InitDisplay();
    }

    public override void OnPass()
    {
        if (isMultiplier)
            _soldierSpawner.Multiply(value);
        else
            _soldierSpawner.Divide(value);

        Destroy(gameObject);
    }

    protected override void InitDisplay()
    {
        NotifyValueChanged(isMultiplier ? "x" : "/", value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SoldierCollision>(out SoldierCollision soldier))
        {
            OnPass();
        }
    }
}
