using UnityEngine;

public class StaticArch : ArchBase
{
    public enum OperationType { Multiply, Divide }
    public OperationType operation = OperationType.Multiply;
    public int value = 2;

    public override void OnPlayerPass(Player player)
    {
        if (operation == OperationType.Multiply)
            soldierCount *= value;
        else if (operation == OperationType.Divide && value != 0)
            soldierCount /= value;

        SpawnSoldiers(player);
    }
}
