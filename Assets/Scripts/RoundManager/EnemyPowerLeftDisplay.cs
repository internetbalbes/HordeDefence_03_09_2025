using UnityEngine;
using TMPro;

public class EnemyPowerLeftDisplay : MonoBehaviour
{
    public TextMeshProUGUI _enemyPowerLeft;
    public RoundManager roundManager;

    private void UpdateDisplay(int amount)
    {
        _enemyPowerLeft.text = amount.ToString();
    }
}
