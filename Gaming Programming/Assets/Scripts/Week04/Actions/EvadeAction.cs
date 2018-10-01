using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeAction : Action
{
    public override void Act(StateController controller)
    {
        Transform transform = controller.gameObject.transform;
        GameObject enemy = controller.enemy;
        float speed = controller.speed;

        Vector3 p0 = transform.position;
        Vector3 p1 = enemy.transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p0 - p1).normalized;
        //newPos.y = 0.5f;
        transform.position = newPos;
        //throw new System.NotImplementedException();
    }
}

