using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private RoundDuration _roundDuration;

    [SerializeField] private int _money = 0;

    public UnityAction<int> MoneyChanged;

    public void Add(int amount)
    {
        _money += amount;
        MoneyChanged?.Invoke(_money);
    }

    public void Subtract(int amount)
    {
        if (_money - amount >= 0)
        {
            _money -= amount;
            MoneyChanged?.Invoke(_money);
        }
    }

    private void Start()
    {
        _money = PlayerPrefs.GetInt("money",0);
        MoneyChanged?.Invoke(_money);
    }

    private void OnEnable()
    {
        _roundDuration.Finished += Add;
    }

    private void OnDisable()
    {
        _roundDuration.Finished -= Add;
    }
}
