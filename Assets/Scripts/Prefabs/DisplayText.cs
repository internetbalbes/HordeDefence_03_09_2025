using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))
]
public class DisplayText : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro => GetComponent<TextMeshProUGUI>();

    public void UpdateText(int value)
    {
        _textMeshPro.text = value.ToString();
    }
}
