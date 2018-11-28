using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public GameObject PU;
    public Transform SpawnPower;
    public int Power = 0;
    public float timer;
    public int ts = 0;
    public float waitTime = 30f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if(ts == 1) { 
        timer += Time.deltaTime;
            if (timer > waitTime)
            {
                ts = 0;
                print("Timer is done");
                timer = 0f;
                Power = 0;
                Instantiate(PU, SpawnPower.transform.position, Quaternion.identity);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("PowerUp"))
        {
            ts = 1;
            Power = 1;
            Destroy(other.gameObject);
        }
        if (other.collider.CompareTag("Enemy") && Power == 0)
        {
            Destroy(this.gameObject);
        }

        if (other.collider.CompareTag("Enemy") && Power == 1)
        {
            Destroy(other.gameObject);
        }
    }
}
