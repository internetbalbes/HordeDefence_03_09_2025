using UnityEngine;
using TMPro;

public class EnemyPowerLeftDisplay : MonoBehaviour
{
    public TextMeshProUGUI _enemyPowerLeft;
    public RoundManager roundManager;

    private void OnEnable() => roundManager.OnEnemiesRemainingChanged += UpdateDisplay;
    private void OnDisable() => roundManager.OnEnemiesRemainingChanged -= UpdateDisplay;

    private void UpdateDisplay(int amount)
    {
        _enemyPowerLeft.text = amount.ToString();
    }
}
