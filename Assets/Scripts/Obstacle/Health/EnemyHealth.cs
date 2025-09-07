using UnityEngine;
using System;

public class EnemyHealth : Health
{
    public static Action<GameObject> Dead;

    protected override void OnHealthPointsZero()
    {
        Dead?.Invoke(gameObject);
    }
}
