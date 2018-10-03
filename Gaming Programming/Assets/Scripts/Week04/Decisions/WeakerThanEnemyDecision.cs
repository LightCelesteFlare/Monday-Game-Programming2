using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/WeakerThanEnemy")]
public class WeakerThanEnemyDecision : Decision {
    public override bool Decide(StateController controller)
    {
        StrongerThanEnemyDecision STED = new StrongerThanEnemyDecision();
        return !STED.Decide(controller);
    }
}
