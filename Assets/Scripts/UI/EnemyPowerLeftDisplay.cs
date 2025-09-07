using UnityEngine;
using TMPro;

public class EnemyPowerLeftDisplay : MonoBehaviour
{
    public TextMeshProUGUI _enemyPowerLeft;
    public RoundManager roundManager;

    private void OnEnable() => roundManager.CurrentEnemiesCountChanged += UpdateDisplay;
    private void OnDisable() => roundManager.CurrentEnemiesCountChanged -= UpdateDisplay;

    private void UpdateDisplay(int amount)
    {
        _enemyPowerLeft.text = amount.ToString();
    }
}
