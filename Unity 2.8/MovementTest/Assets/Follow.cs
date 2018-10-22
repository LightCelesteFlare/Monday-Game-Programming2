using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject player;
    public GameObject egg;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public float FollowSpeed;
    public RaycastHit shot;

	
	// Update is called once per frame
	void Update () {

        //FollowSpeed = 0f;


        //transform.LookAt(player.transform);
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        //{
        //    TargetDistance = shot.distance;
        //    if (TargetDistance >= AllowedDistance)
        //    {
        //        FollowSpeed = 0.02f;
        //        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, FollowSpeed);
        //    }
        //    else
        //    {
        //        FollowSpeed = 0f;
        //    }
        //}

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {

            transform.LookAt(player.transform);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                TargetDistance = shot.distance;
                if (TargetDistance >= AllowedDistance)
                {
                    FollowSpeed = 0.5f;
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, FollowSpeed);
                }
                else
                {
                    FollowSpeed = 0f;
                }
            }
        }
    }

}
