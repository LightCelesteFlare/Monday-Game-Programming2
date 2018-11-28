using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
   // public GameObject Player;
    public GameObject Enemy;
    public GameObject PowerUp;
   // public Transform PosP;
    public Transform PosE;
    public Transform PosPU;
    public int counter = 1;
    public float timer;
    public float waitTime = 5f;
    // Use this for initialization
    void Start () {
        //Instantiate(Player, PosP.position, Quaternion.identity);
        Instantiate(Enemy, PosE.position, Quaternion.identity);
        Instantiate(PowerUp, PosPU.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            timer = 0f;
            
            for (int i = 0; i < counter; i++)
            {
                Instantiate(Enemy, PosE.position, Quaternion.identity);
            }
            if (counter <= 6) { 
            counter++;
                waitTime -= .5f;
            }
        }
    }
}

