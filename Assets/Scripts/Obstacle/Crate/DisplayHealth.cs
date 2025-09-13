using TMPro;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CrateHealth _createHealth;

    private void OnEnable()
    {
        _createHealth.CrateDamaged += Display;
    }

    private void OnDisable()
    {
        _createHealth.CrateDamaged -= Display;
    }

    private void Display(int value)
    {
        _text.text = value.ToString();
    }
}
