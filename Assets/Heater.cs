using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heater : MonoBehaviour
{

    public GameObject airGenerator;

    public static float carbonChance = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Molecule"))
        {
            if (!other.GetComponent<MoleculeMovement>().isHeated() && !other.GetComponent<MoleculeMovement>().isCarbon())
            {
                if(Random.Range(0, 100) < carbonChance)
                {
                    other.GetComponent<MoleculeMovement>().createCarbon();
                    airGenerator.GetComponent<AirGenerator>().carbonMonoxide.Add(other);
                    airGenerator.GetComponent<AirGenerator>().coldAir.Remove(other);
                }
                else
                {
                    other.GetComponent<MoleculeMovement>().HeatUp();
                    airGenerator.GetComponent<AirGenerator>().hotAir.Add(other);
                    airGenerator.GetComponent<AirGenerator>().coldAir.Remove(other);
                }                           
            }           
        }
    }
}
