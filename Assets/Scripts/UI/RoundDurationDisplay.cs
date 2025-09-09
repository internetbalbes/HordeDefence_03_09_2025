using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class RoundDurationDisplay : MonoBehaviour
{
    private RoundDuration _roundDuration => GetComponent<RoundDuration>();
    private TextMeshPro _roundDurationText => GetComponent<TextMeshPro>();

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
