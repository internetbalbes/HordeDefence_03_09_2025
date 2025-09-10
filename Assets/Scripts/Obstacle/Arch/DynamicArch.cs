using UnityEngine;

public class DynamicArch : ArchBase
{
    [SerializeField] private int _soldierCountChange = 1;

    public override void OnPass()
    {
        if (_player == null) return;

        _player.AddSoldier();
        NotifyValueChanged(_soldierCountChange >= 0 ? "+" : "-", Mathf.Abs(_soldierCountChange));
    }

    public void OnRaycastHit()
    {
        if (_player == null) return;

        _player.AddSoldier();
        NotifyValueChanged(_soldierCountChange >= 0 ? "+" : "-", Mathf.Abs(_soldierCountChange));
    }

    protected override void InitDisplay()
    {
        NotifyValueChanged(_soldierCountChange >= 0 ? "+" : "-", Mathf.Abs(_soldierCountChange));
    }
}
