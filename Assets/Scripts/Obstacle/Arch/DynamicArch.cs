using UnityEngine;
using UnityEngine.Events;

public class DynamicArch : ArchBase
{
    public UnityAction<int> SoldierCountChanged;

    public void Start()
    {
        _value = _initialSoldierCount;
        SoldierCountChanged?.Invoke(_value);
    }

    public override void OnRaycastHit()
    {
        _value++;
        SoldierCountChanged?.Invoke(_value);
    }

    public override void OnPlayerPass(Player player)
    {
        SpawnSoldiers(player);
    }

    private void OnEnable()
    {
        _value = _initialSoldierCount;
        SoldierCountChanged?.Invoke(_value);
    }
}
