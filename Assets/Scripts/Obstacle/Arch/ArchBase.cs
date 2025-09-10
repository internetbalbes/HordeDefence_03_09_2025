using UnityEngine;

public abstract class ArchBase : MonoBehaviour
{
    protected int _initialSoldierCount = 1;
    protected int _value = 1;

    public abstract void OnPlayerPass(Player player);

    public virtual void OnRaycastHit() { }

    protected void SpawnSoldiers(Player player)
    {
        for (int i = 0; i < _value; i++)
        {
            player.AddSoldier();
        }
    }
}
