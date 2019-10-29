using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeMovement : MonoBehaviour
{
    public Vector3 velocity = new Vector3(15.0f, 15.0f, 15.0f);
    public float temperature = 0.0f;
    
    private Rigidbody rb;
    private Vector3 currentMovementDirection;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
        rb = GetComponent<Rigidbody>();       
        transform.rotation = UnityEngine.Random.rotation;
        
        currentMovementDirection = transform.forward * 5.0f;
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        rb.velocity = currentMovementDirection;
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
        transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50.0f, 0), ForceMode.Impulse);
    }
}
