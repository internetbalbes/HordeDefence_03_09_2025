using UnityEngine;

public class SoldierShooting : MonoBehaviour
{
    private float _shootCooldown = 0.75f;
    private int _rayDistance = 45;
    private int _shootDamage = 1;

    private float _timer = 0f;

    public ParticleSystem shootCollisionParticles;

    [SerializeField] private LayerMask shootableLayers;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _shootCooldown)
        {
            Shoot();
            _timer = 0f;
        }
    }

    private void Shoot()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance, shootableLayers))
        {
            if (hit.collider.TryGetComponent<Health>(out Health obj))
                obj.TakeDamage(_shootDamage);

            shootCollisionParticles.Play();
            shootCollisionParticles.transform.position = hit.point;
        }
    }
}
