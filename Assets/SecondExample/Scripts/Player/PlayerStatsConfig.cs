using UnityEngine;

[CreateAssetMenu(menuName = "Player/StatsConfig", fileName = "PlayerStatsConfig")]
public class PlayerStatsConfig : ScriptableObject
{
    [field: SerializeField, Range(1, 50)] public int MaxHealth { get; private set; }
}
