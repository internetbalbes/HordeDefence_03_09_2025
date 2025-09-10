using UnityEngine;

public class StaticArch : ArchBase
{
    public enum OperationType { Multiply, Divide }
    public OperationType operation = OperationType.Multiply;
    public int value = 2;

    public override void OnPass()
    {
        if (_player == null) return;

        if (operation == OperationType.Multiply)
            _player.MultiplySoldiers(value);
        else if (operation == OperationType.Divide)
            _player.DivideSoldiers(value);
    }

    protected override void InitDisplay()
    {
        string sign = operation == OperationType.Multiply ? "×" : "/";
        NotifyValueChanged(sign, value);
    }
}
