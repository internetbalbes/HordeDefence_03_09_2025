using TMPro;
using UnityEngine;

public class DisplayWallet : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    [SerializeField] private TextMeshProUGUI _text;

    private void OnMoneyChanged(int amount)
    {
        _text.text = amount.ToString();
    }

    private void OnEnable()
    {
        _wallet.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _wallet.MoneyChanged -= OnMoneyChanged;
    }
}
