using UnityEngine;
using TMPro;

public class ArchSoldierCountDisplay : MonoBehaviour
{
    [SerializeField] private DynamicArch _arch;
    [SerializeField] private TextMeshProUGUI _soldierCountText;

    private void Start()
    {
        _soldierCountText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _arch.SoldierCountChanged += OnSoldierCountChanged;
    }

    private void OnDisable()
    {
        _arch.SoldierCountChanged -= OnSoldierCountChanged;
    }

    private void OnSoldierCountChanged(int soldierCount)
    {
        if (soldierCount > 0)
            _soldierCountText.text = "+" + soldierCount.ToString();
        if (soldierCount < 0)
            _soldierCountText.text = "-" + soldierCount.ToString();
    }
}
