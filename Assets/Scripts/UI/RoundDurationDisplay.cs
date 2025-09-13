using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class RoundDurationDisplay : MonoBehaviour
{
    [SerializeField] private RoundDuration _roundDuration;
    [SerializeField] private TextMeshProUGUI _roundDurationText;

    private void OnEnable()
    {
        _roundDuration.RoundDurationChanged += OnRoundDurationChanged;
    }

    private void OnDisable()
    {
        _roundDuration.RoundDurationChanged -= OnRoundDurationChanged;
    }

    private void OnRoundDurationChanged(int roundDuration)
    {
        _roundDurationText.text = roundDuration.ToString();
    }
}
