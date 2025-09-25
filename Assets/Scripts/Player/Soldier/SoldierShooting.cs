using UnityEngine;

public class SoldierShooting : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private LayerMask _shootableLayers = 1 << 0;

    private static SoldierEquipment _soldierEquipment;

    private float _shootTimer = 0f;

    private void Awake()
    {
        if (_soldierEquipment == null)
            _soldierEquipment = SoldierEquipment.Instance;
    }

    private void Update()
    {
        _shootTimer += Time.deltaTime;

        if (_shootTimer >= _soldierEquipment.FireRate)
        {
            Shoot();
            _shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _soldierEquipment.Range, _shootableLayers))
        {
            if (hit.collider.TryGetComponent<DynamicArch>(out DynamicArch dynamicBase))
                dynamicBase.OnRaycastHit();

            if (hit.collider.TryGetComponent<IDamageable>(out IDamageable damageableObject))
                damageableObject.TakeDamage(_soldierEquipment.Damage);

            _hitEffect.transform.position = hit.point;
            _hitEffect.Play();
        }
    }
}
