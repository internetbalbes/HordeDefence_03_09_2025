using UnityEngine;
using UnityEngine.Events;

public class SoldierEquipment : MonoBehaviour
{
    public static SoldierEquipment Instance { get; private set; }

    public event UnityAction<Sprite> GunEquiped;

    [SerializeField] private Run _run;

    [SerializeField] private Gun _defaultGun;

    private int _range = 0;
    private int _damage = 0;
    private float _fireRate = 0;

    internal int Range => _range;
    internal int Damage => _damage;
    internal float FireRate => _fireRate;

    private void Awake()
    {
        Instance = this;
    }

    public void EquipGun(Gun gun)
    {
        _damage = gun.damage;
        _range = gun.range;
        _fireRate = gun.fireRate;

        GunEquiped?.Invoke(gun.gunImage);
    }

    private void OnEnable()
    {
        EquipGun(_defaultGun);
        CrateHealth.CrateDestroyed += EquipGun;
    }

    private void OnDisable()
    {
        CrateHealth.CrateDestroyed -= EquipGun;
    }
}