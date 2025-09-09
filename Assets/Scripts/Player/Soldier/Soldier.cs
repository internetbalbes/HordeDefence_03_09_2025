using UnityEngine;

public class Soldier : MonoBehaviour
{
    protected int damage = 1;
    protected float range = 15f;
    protected float fireRate = 0.5f;

    public void EquipGun(Gun gun)
    {
        damage = gun.damage;
        range = gun.range;
        fireRate = gun.fireRate;
    }

    private void OnEnable()
    {
        CrateHealth.CrateDestroyed += EquipGun;
    }

    private void OnDisable()
    {
        CrateHealth.CrateDestroyed -= EquipGun;
    }
}
