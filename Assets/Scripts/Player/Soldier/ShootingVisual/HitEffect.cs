using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private float _lifetime = 1f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Play(Vector3 position, Vector3 normal)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(normal);
        gameObject.SetActive(true);
        CancelInvoke();
        Invoke(nameof(Stop), _lifetime);
    }

    private void Stop()
    {
        gameObject.SetActive(false);
    }
}
