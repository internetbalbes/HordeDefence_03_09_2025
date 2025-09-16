using UnityEngine;
using UnityEngine.UI;

public class CurrentGunDisplay : RunUIActive
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        CrateHealth.CrateDestroyed += UpdateImage;
    }

    private void OnDisable()
    {
        CrateHealth.CrateDestroyed -= UpdateImage;
    }

    private void UpdateImage(Gun gun)
    {
        _image.sprite = gun.gunImage;
    }
}
