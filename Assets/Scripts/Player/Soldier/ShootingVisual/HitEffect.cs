using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private float lifetime = 1f;

    public void Play(Vector3 position, Vector3 normal)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(normal);
        gameObject.SetActive(true);
        CancelInvoke();
        Invoke(nameof(Stop), lifetime);
    }

    private void Stop()
    {
        gameObject.SetActive(false); // выключаем эффект после жизни
    }
}
