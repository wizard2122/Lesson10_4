using UnityEngine;

public interface IEnemyTarget : IDamageable
{
    Vector3 Position { get; }
}
