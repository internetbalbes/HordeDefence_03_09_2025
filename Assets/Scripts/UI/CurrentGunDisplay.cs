using UnityEngine;
using UnityEngine.UI;

public class CurrentGunDisplay : RunUIActive
{
    [SerializeField] private SoldierEquipment _soldierEquipment;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _soldierEquipment.GunEquiped += UpdateImage;
    }

    private void OnDisable()
    {
        _soldierEquipment.GunEquiped -= UpdateImage;
    }

    private void UpdateImage(Sprite gunImage)
    {
        _image.sprite = gunImage;
    }
}
