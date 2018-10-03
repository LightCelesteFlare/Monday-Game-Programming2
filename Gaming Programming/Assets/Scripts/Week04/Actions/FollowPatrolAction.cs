using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PluggableAI/Actions/FollowPatrol")]
public class FollowPatrolAction : Action {
    public override void Act(StateController controller)
    {
        Transform transform = controller.gameObject.transform;
        GameObject enemy = controller.enemy;
        float speed = controller.speed;

        controller.nextWaypoint = controller.CalculateNextWaypoint();
        //Vector3 p0 = Waypoints[currentWaypoint].transform.position;
        Vector3 p0 = transform.position;
        Vector3 p1 = controller.Waypoints[controller.nextWaypoint].transform.position;
        Vector3 newPos = transform.position + speed * Time.deltaTime * (p1 - p0).normalized;
        transform.position = newPos;
        if ((newPos - p1).magnitude < .5)
        {
            controller.currentWaypoint = controller.nextWaypoint;
        }
    }
}
