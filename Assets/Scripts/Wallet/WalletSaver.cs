using UnityEngine;

[RequireComponent(typeof(Wallet))]

public class WalletSaver : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void OnMoneyChanged(int amount)
    {
        PlayerPrefs.SetInt("money", amount);
        PlayerPrefs.Save();
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
