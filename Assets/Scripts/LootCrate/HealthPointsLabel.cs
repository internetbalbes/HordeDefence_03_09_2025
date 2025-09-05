using UnityEngine;
using TMPro;

public class HealthPointsLabel : MonoBehaviour
{
    public Health lootCrateHealth;

    private TextMeshProUGUI healthPointsText;
    
    private void Start()
    {
        healthPointsText = GetComponent<TextMeshProUGUI>();
    }
    private void UpdateHealthPointDisplay()
    {
        healthPointsText.text = lootCrateHealth.GetHealth().ToString();
    }
    private void OnEnable() => lootCrateHealth.HealthPointsChanged += UpdateHealthPointDisplay;
    private void OnDisable() => lootCrateHealth.HealthPointsChanged -= UpdateHealthPointDisplay;
}
