using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BigOhExercise : MonoBehaviour
{
    public float NumberOfElements = 10;

    // Use this for initialization
    void Start()
    {
        //int[] numbers = new int[NumberOfElements];
        DateTime t1 = DateTime.Now;
        ArrayList al = new ArrayList();
        for (int i = 0; 1 < NumberOfElements; i++)
        {
            al.Add(UnityEngine.Random.Range(0, NumberOfElements));
        }
        DateTime t2 = DateTime.Now;

        al.Sort();
        DateTime t3 = DateTime.Now; ;
        Debug.Log("t:" + t1.Millisecond);
        Debug.Log("t:" + t2.Millisecond);
        Debug.Log("t:" + t3.Millisecond);
    }


    // Update is called once per frame
    void Update()
    {

    }
}