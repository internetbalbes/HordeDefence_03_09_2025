using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Run _run;

    private void OnEnable()
    {
        _run.Started += OnRunStarted;
    }

    private void OnDisable()
    {
        _run.Started -= OnRunStarted;
    }

    private void OnRunStarted()
    {
        gameObject.SetActive(false);
    }
}
