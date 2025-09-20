using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/Gun")]
public class Gun : ScriptableObject
{
    public int damage;
    public float fireRate;
    public int range;
    public Sprite gunImage;
}
