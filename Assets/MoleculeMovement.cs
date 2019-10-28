using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeMovement : MonoBehaviour
{
    public float velocity = 2.0f;
    public float temperature = 15.0f;

    private bool oneTime = true;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
        //transform.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-velocity, velocity), Random.Range(-velocity, velocity), Random.Range(-velocity, velocity)), ForceMode.Impulse);
        //transform.GetComponent<Rigidbody>().AddForce(new Vector3(1.0f, 3.0f, 0));
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        if (oneTime)
        {
            //GetComponent<Rigidbody>().AddForce(impulseMagnitude, ForceMode.Impulse);
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-velocity, velocity), Random.Range(-velocity, velocity), Random.Range(-velocity, velocity)), ForceMode.Impulse);
            oneTime = false;
        }
    }


    public void HeatUp()
    {
        GetComponent<Renderer>().material.color = Color.red;
        transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50.0f, 0), ForceMode.Impulse);
    }
}
