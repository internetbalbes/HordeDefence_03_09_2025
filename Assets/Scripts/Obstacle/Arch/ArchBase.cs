using UnityEngine;
using UnityEngine.Events;

public abstract class ArchBase : MonoBehaviour
{
    public UnityAction<int> SoldierCountChanged;

    protected int soldierCount = 1;

    public abstract void OnPlayerPass(Player player);

    public virtual void OnRaycastHit() { }

    protected void SpawnSoldiers(Player player)
    {
        for (int i = 0; i < soldierCount; i++)
        {
            player.AddSoldier();
        }
    }

    private void OnEnable()
    {
        SoldierCountChanged?.Invoke(soldierCount);
    }
}
