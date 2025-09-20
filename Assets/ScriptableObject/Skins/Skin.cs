using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "Scriptable Objects/Skin")]
public class Skin : ScriptableObject
{
    public GameObject prefab;
    public int price;
}
