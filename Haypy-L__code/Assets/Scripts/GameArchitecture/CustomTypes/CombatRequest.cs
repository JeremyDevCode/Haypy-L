using UnityEngine;

[System.Serializable]
public class CombatRequest
{
    public CombatUnitSO player;
    public Transform playerPosition;

    public CombatUnitSO[] enemies;
    public Transform enemyPosition;

    public CombatRequest(CombatUnitSO player, Transform playerPosition, CombatUnitSO[] enemies, Transform enemyPosition)
    {
        this.player = player;
        this.playerPosition = playerPosition;
        this.enemies = enemies;
        this.enemyPosition = enemyPosition;
    }
}
