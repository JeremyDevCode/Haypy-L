using UnityEngine;
using ScriptableObjectArchitecture;

public class CombatTrigger : MonoBehaviour
{
    [Header("Configuration")]
    public CombatUnitSO player;
    public Transform playerPosition;
    public CombatUnitSO[] enemies;
    public Transform enemyPosition;

    [Header("Broadcasting events")]
    public CombatRequestGameEvent combatRequestEvent;

    public void TriggerCombat()
    {
        var combatRequest = new CombatRequest(
            player: this.player,
            playerPosition: this.playerPosition,
            enemies: enemies,
            enemyPosition: this.enemyPosition
        );

        this.combatRequestEvent.Raise(combatRequest);
    }
}
