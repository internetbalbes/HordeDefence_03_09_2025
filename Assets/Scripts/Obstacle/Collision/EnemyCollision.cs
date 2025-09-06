using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EndZone>(out EndZone endZone))
        {
            endZone.restartGame.RestartCurrentScene();
        }
    }
}
