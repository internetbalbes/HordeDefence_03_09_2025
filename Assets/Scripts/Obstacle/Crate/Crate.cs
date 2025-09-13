using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    [SerializeField] private Image _gunIcon;

    public static UnityAction<Crate> CrateCreated;

    protected Gun _gun;

    public void Gun(Gun gun)
    {
        _gun = gun;
        _gunIcon.sprite = gun.gunImage;
    }

    public Gun GetGun()
    {
        return _gun;
    }

    private void OnEnable()
    {
        CrateCreated?.Invoke(this);
    }
}
