using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnEnable() => LootCrateCollisionHandler.PlayerCollidedLootCrate += RestartCurrentScene;
    private void OnDisable() => LootCrateCollisionHandler.PlayerCollidedLootCrate -= RestartCurrentScene;
}
