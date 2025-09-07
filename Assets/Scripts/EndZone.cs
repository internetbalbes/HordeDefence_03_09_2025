using UnityEngine;

public class EndZone : MonoBehaviour
{
    [SerializeField] private RestartGame _restartGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ObstacleMovement>(out _))
        {
            _restartGame.GameRestart();
        }
    }
}
