using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Decisions/Threatened")]
public class ThreatenedDecision : Decision {

    public override bool Decide(StateController controller)
    {
        SafeDecision safe = new SafeDecision();
        return !safe.Decide(controller);
    }
}
