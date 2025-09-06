using UnityEngine;
using UnityEngine.Events;

public class Pawn : MonoBehaviour
{
    public static UnityAction<GameObject> Killed;

    public void Kill()
    {
        Killed?.Invoke(gameObject);
        gameObject.SetActive(false);
    }
}
