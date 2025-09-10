using UnityEngine;

public class DynamicArch : ArchBase
{
    public int increment = 1;

    public override void OnRaycastHit()
    {
        soldierCount += increment;
        SoldierCountChanged?.Invoke(soldierCount);
    }

    public override void OnPlayerPass(Player player)
    {
        SpawnSoldiers(player);
    }
}
