using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeMovement : MonoBehaviour
{
    public float initialTemperature = 200f;
    public float temperature = 200f;
    public float mass = 0.010126f;

    private Rigidbody rb;
    private Vector3 currentMovementDirection;
    private Vector3 lastPos;
    private bool heated = false;
    private bool carbon = false;
    public int room;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
        rb = GetComponent<Rigidbody>();
        transform.rotation = UnityEngine.Random.rotation;

        currentMovementDirection = transform.forward * KineticEnergy();
        lastPos = transform.position;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReflectProjectile();
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
        temperature = 2233.15f;
        currentMovementDirection = transform.forward * KineticEnergy();
        heated = true;
    }

    public void HeatDown()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
        temperature = initialTemperature;
        currentMovementDirection = transform.forward * KineticEnergy();
        heated = false;
    }

    public void createCarbon()
    {
        GetComponent<Renderer>().material.color = Color.black;
        temperature = 2233.15f;
        currentMovementDirection = transform.forward * KineticEnergy();
        carbon = true;
        heated = true;
    }

    public bool isHeated()
    {
        return heated;
    }

    public bool isCarbon()
    {
        return carbon;
    }

    public float KineticEnergy()
    {
        double rms = (3.0f * 1.38f * temperature) / mass;
        return ((float)Math.Sqrt(rms)) / 100.0f;
    }

    public void SetInitialTemperature(float temperature)
    {
        initialTemperature = temperature;
        this.temperature = temperature;
    }

    public void changeRoom()
    {
        if (room == 1)
        {
            room = 2;
        }
        else
        {
            room = 1;
        }
    }

    public void changeRoom(int roomNr)
    {
        room = roomNr;
    }
}
