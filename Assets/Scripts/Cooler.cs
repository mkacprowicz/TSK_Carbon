using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Molecule"))
        {
            if (collision.collider.GetComponent<MoleculeMovement>().isHeated())
            {
                collision.collider.GetComponent<MoleculeMovement>().HeatDown();
            }
        }
    }
}
