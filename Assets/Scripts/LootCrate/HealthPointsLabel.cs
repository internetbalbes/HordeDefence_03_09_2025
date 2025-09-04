using UnityEngine;
using TMPro;

public class HealthPointsLabel : MonoBehaviour
{
    public LootCrate lootCrate;

    private TextMeshProUGUI healthPointsText;
    
    private void Start()
    {
        healthPointsText = GetComponent<TextMeshProUGUI>();
    }
    private void UpdateHealthPointDisplay(int healthPoints)
    {
        healthPointsText.text = healthPoints.ToString();
    }
    private void OnEnable() => lootCrate.HealthPointsChanged += UpdateHealthPointDisplay;
    private void OnDisable() => lootCrate.HealthPointsChanged -= UpdateHealthPointDisplay;
}
