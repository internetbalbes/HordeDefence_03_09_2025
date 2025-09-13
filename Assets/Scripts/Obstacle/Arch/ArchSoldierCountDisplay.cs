using UnityEngine;
using TMPro;

public class ArchSoldierCountDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _soldierCountText;
    private ArchBase _arch;

    private void Awake()
    {
        _arch = GetComponent<ArchBase>();
    }

    private void OnEnable()
    {
        _arch.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _arch.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(string sign, int value)
    {
        _soldierCountText.text = sign + value.ToString();
    }
}
