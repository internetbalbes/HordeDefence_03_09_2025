using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class RoundScoreDisplay : MonoBehaviour
{
    [SerializeField] private RoundScore _roundScore;
    [SerializeField] private TextMeshProUGUI _roundScoreText;

    private void OnEnable()
    {
        _roundScore.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _roundScore.Changed -= OnChanged;
    }

    private void OnChanged(int roundScore)
    {
        _roundScoreText.text = roundScore.ToString();
    }
}
