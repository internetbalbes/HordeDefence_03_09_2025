using UnityEngine;
using TMPro;

public class ArchSoldierCountDisplay : MonoBehaviour
{
    [SerializeField] private ArchBase _arch;
    private TextMeshProUGUI _soldierCountText;

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
        _soldierCountText.text = soldierCount.ToString();
    }
}
