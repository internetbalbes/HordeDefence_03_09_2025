using UnityEngine;
using UnityEngine.Events;

public abstract class ArchBase : MonoBehaviour
{
    protected static SoldierSpawner _soldierSpawner => FindFirstObjectByType<SoldierSpawner>();

    public UnityAction<string, int> ValueChanged;

    public abstract void OnPass();

    protected abstract void InitDisplay();

    private void Start()
    {
        InitDisplay();
    }

    protected void NotifyValueChanged(string sign, int value)
    {
        ValueChanged?.Invoke(sign, value);
    }
}
