using UnityEngine;
using UnityEngine.Events;

public abstract class ArchBase : MonoBehaviour
{
    protected static Player _player => FindFirstObjectByType<Player>();

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
