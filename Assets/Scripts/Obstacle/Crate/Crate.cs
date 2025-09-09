using UnityEngine;
using UnityEngine.UI;

public class Crate : MonoBehaviour
{
    [SerializeField] private Image _gunIcon;

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
}
