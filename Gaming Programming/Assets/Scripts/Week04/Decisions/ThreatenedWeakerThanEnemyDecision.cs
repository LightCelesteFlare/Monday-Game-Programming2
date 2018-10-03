using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatenedWeakerThanEnemyDecision : Decision {
    public override bool Decide(StateController controller)
    {
        ThreatenedStrongerThanEnemyDecision TSTED = new ThreatenedStrongerThanEnemyDecision();
        return !TSTED.Decide(controller);
    }
}
