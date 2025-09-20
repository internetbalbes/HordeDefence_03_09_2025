using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoldierSpawner))]
public class SoldierFormation : MonoBehaviour
{
    [SerializeField] private SoldierSpawner _soldierSpawner;
    private List<GameObject> _soldiers;

    [SerializeField] private Transform _player;
    [SerializeField] private float _spacing = 0;
    [SerializeField] private float _heightOffset = 0.5f;

    private void Awake()
    {
        _soldiers = _soldierSpawner._soldiers;
    }

    private void OnEnable()
    {
        _soldierSpawner.SoldiersAmountChanged += UpdateFormation;
    }

    private void OnDisable()
    {
        _soldierSpawner.SoldiersAmountChanged -= UpdateFormation;
    }

    private void UpdateFormation()
    {
        _soldiers.RemoveAll(s => s == null);

        int count = _soldiers.Count;
        if (count == 0) return;

        int gridSize = Mathf.CeilToInt(Mathf.Sqrt(count));
        int i = 0;

        float halfGrid = (gridSize - 1) / 2f;

        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                if (i >= count) return;

                float offsetX = (x - halfGrid) * _spacing;
                float offsetZ = (z - halfGrid) * _spacing;
                Vector3 offset = new Vector3(offsetX, _heightOffset, offsetZ);

                var following = _soldiers[i].GetComponent<PlayerFollowing>();
                following.SetOffset(offset, _player);
                i++;
            }
        }
    }
}
