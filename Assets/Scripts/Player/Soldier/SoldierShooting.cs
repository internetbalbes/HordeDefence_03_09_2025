using UnityEngine;

public class SoldierShooting : Soldier
{
    [SerializeField] private LayerMask shootableLayers;
    [SerializeField] private BulletTracer bulletTracer;      // готовый объект пули
    [SerializeField] private ParticleSystem hitEffect;        // готовый объект эффекта попадания
    [SerializeField] private float bulletSpeed = 200f;

    private float _shootTimer = 0f;

    private void Update()
    {
        _shootTimer += Time.deltaTime;

        if (_shootTimer >= fireRate)
        {
            Shoot();
            _shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, range, shootableLayers))
        {
            // логика урона
            if (hit.collider.TryGetComponent<IDamageable>(out IDamageable obstacle))
                obstacle.TakeDamage(damage);

            if (hit.collider.TryGetComponent<DynamicArch>(out DynamicArch arch))
                arch.OnRaycastHit();

            // визуальная пуля
            bulletTracer.gameObject.SetActive(true);
            bulletTracer.Shoot(transform.position, hit.point, bulletSpeed);

            // эффект попадания / взрыва
            hitEffect.transform.position = hit.point;
            hitEffect.transform.rotation = Quaternion.LookRotation(hit.normal);
            hitEffect.Play();
        }
    }
}
