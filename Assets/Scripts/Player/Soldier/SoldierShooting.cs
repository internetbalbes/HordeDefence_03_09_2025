using UnityEngine;

public class SoldierShooting : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private LayerMask _shootableLayers = 1 << 0;

    [SerializeField] private static int _range;
    [SerializeField] private static int _damage;
    [SerializeField] private static float _fireRate;

    [SerializeField] private Gun _defaultGun;

    private float _shootTimer = 0f;

    private void OnRunStarted()
    {
        EquipGun(_defaultGun);
    }

    private void FixedUpdate()
    {
        _shootTimer += Time.deltaTime;

        if (_shootTimer >= _fireRate)
        {
            Shoot();
            _shootTimer = 0f;
        }
    }

    public void EquipGun(Gun gun)
    {
        _damage = gun.damage;
        _range = gun.range;
        _fireRate = gun.fireRate;
    }
    
    private void OnEnable()
    {
        CrateHealth.CrateDestroyed += EquipGun;
    }

    private void OnDisable()
    {
        CrateHealth.CrateDestroyed -= EquipGun;
    }

    private void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _range, _shootableLayers))
        {
            if (hit.collider.TryGetComponent<EnemyHealth>(out EnemyHealth obstacle))
                obstacle.TakeDamage(_damage);

            if (hit.collider.TryGetComponent<DynamicArch>(out DynamicArch dynamicBase))
                dynamicBase.OnRaycastHit();

            if (hit.collider.TryGetComponent<CrateHealth>(out CrateHealth crate))
                crate.TakeDamage(_damage);



            _hitEffect.transform.position = hit.point;
            _hitEffect.Play();
        }
    }
}
