using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackEnemy")]
public class AttackEnemyAction : Action
{
    public override void Act(StateController controller)
    {
        Debug.Log("In AttackEnemyAction.ActAttack");
    }
}
