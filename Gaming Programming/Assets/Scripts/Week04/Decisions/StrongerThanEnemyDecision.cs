using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/StrongerThanEnemy")]
public class StrongerThanEnemyDecision : Decision {
    public override bool Decide(StateController controller)
    {
        return controller.strength < controller.enemy.GetComponent<EnemyProperties>().BattleRating;
    }
}
