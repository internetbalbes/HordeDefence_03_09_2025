using UnityEngine;
using TMPro;

public class ArchSoldierCountDisplay : MonoBehaviour
{
    [SerializeField] private ArchBase _arch;
    [SerializeField] private TextMeshProUGUI _soldierCountText;

    private void Start()
    {
        _soldierCountText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        if (_arch != null)
            _arch.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        if (_arch != null)
            _arch.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(string sign, int value)
    {
        _soldierCountText.text = sign + value.ToString();
    }
}
