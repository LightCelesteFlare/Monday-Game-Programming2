using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        Transform transform = controller.gameObject.transform;
        GameObject enemy = controller.enemy;
        float SafeDistanceCutoff = controller.SafeDistanceCutoff;

        Vector3 E2T = transform.position - enemy.transform.position;
        float dTE = E2T.magnitude;                                      //Distance
        return dTE > SafeDistanceCutoff;

        //throw new System.NotImplementedException();
    }
}
