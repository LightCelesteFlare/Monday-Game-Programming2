using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatenedStrongerThanEnemyDecision : Decision {
    public override bool Decide(StateController controller)
    {
        ThreatenedDecision td = new ThreatenedDecision();
        if (td.Decide(controller))
        {
            StrongerThanEnemyDecision STED = new StrongerThanEnemyDecision();
            return STED.Decide(controller);
        }
        else
        { 
            return false;
        }
    }
}
