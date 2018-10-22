using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingAI : MonoBehaviour {

    public GameObject Survivor;
    // Rotation speed
    public float Rotspeed = 100f;
    // Bool for the wandering
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    // movement
    public float speed = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Wandering();
    }
    void Wandering()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * Rotspeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -Rotspeed);
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    // 0 - nothing | 1 - right | 2 - left
    IEnumerator Wander()
    {
        // TRGameDev
        int rotTime = Random.Range(1, 3);       // amount of time it rotates
        int rotateWait = Random.Range(1, 3);    // wait for the rotate cycle
        int rotateLorR = Random.Range(0, 3);    // decide if it want to do right or left (bool)
        int walkWait = Random.Range(1, 3);      // walk wait - is the time between walking
        int walkTime = Random.Range(1, 5);      // will be walking

        isWandering = true;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }

}
