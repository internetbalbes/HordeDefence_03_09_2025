using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float _shootCooldown = 0.3f;
    private float _rayDistance = 50f;
    private int _shootDamage = 1;

    private float _timer = 0f;

    public ParticleSystem ShootCollideParticles;

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

        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            ShootCollideParticles.transform.position = hit.point;
            ShootCollideParticles.Play();

            if (hit.collider.TryGetComponent<LootCrate>(out LootCrate lootCrate))
            {
                lootCrate.TakeDamage(_shootDamage);
            }
        }
    }
}
