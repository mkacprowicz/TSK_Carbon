using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeMovement : MonoBehaviour
{
    public Vector3 velocity = new Vector3(15.0f, 15.0f, 15.0f);
    public float temperature = 5.0f;

    private Rigidbody rb;
    private Vector3 currentMovementDirection;
    private Vector3 lastPos;
    private bool heated = false;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
        rb = GetComponent<Rigidbody>();
        transform.rotation = UnityEngine.Random.rotation;

        currentMovementDirection = transform.forward * 5.0f;
        lastPos = transform.position;
        Debug.Log(currentMovementDirection);
    }

    void Update()
    {
        Vector3 offset = transform.position - lastPos;
        if (offset.y > 0.0f)
        {
            lastPos = transform.position;
        }
        else
        {
            //transform.position = transform.position + new Vector3(0, -3.0f, 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = currentMovementDirection;
        //if (heated)
        //{
        //transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5.0f, 0), ForceMode.Impulse);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReflectProjectile();
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        velocity = Vector3.Reflect(velocity, reflectVector);
        rb.velocity = velocity;
    }

    private void ReflectProjectile()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, currentMovementDirection);

        if (Physics.Raycast(ray, out hit))
        {
            currentMovementDirection = Vector3.Reflect(currentMovementDirection, hit.normal);
        }
    }

    public void HeatUp()
    {
        GetComponent<Renderer>().material.color = Color.red;
        currentMovementDirection = new Vector3(0, 1.0f, 0) * 8.0f;
        heated = true;
    }

    public bool isHeated()
    {
        return heated;
    }
}
