using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AirGenerator : MonoBehaviour
{
    public GameObject moleculePrefab;
    public int amount = 1000;
    public float initialTemperature = 200f;

    public Vector3 spanPointMain = new Vector3(0f, 0.5f, 1f);
    public Vector3 spanPointSecond = new Vector3(0f, 0.5f, -1f);

    //public float density;
    public float concentrationFirst;
    public float concentrationSecond;

    private bool generated = false;

    public ArrayList coldAir;
    public ArrayList hotAir;
    public ArrayList carbonMonoxide;

    public int NumR1 = 0;
    public int NumR2 = 0;


    // Start is called before the first frame update
    void Start()
    {
        coldAir = new ArrayList();
        hotAir = new ArrayList();
        carbonMonoxide = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Generate();
        }

        var hotFirst = from GameObject gameObject in hotAir
                       where gameObject.GetComponent<MoleculeMovement>().room == 1
                       select gameObject;

        var coldFirst = from GameObject gameObject in coldAir
                        where gameObject.GetComponent<MoleculeMovement>().room == 1
                        select gameObject;

        var monoFirst = from GameObject gameObject in carbonMonoxide
                        where gameObject.GetComponent<MoleculeMovement>().room == 1
                        select gameObject;


        NumR1 = hotFirst.Count() + coldFirst.Count() + monoFirst.Count();

        concentrationFirst = ((float)monoFirst.Count() / (hotFirst.Count() + coldFirst.Count())) * 100f;


        var hotSecond = from GameObject gameObject in hotAir
                        where gameObject.GetComponent<MoleculeMovement>().room == 2
                        select gameObject;

        var coldSecond = from GameObject gameObject in coldAir
                         where gameObject.GetComponent<MoleculeMovement>().room == 2
                         select gameObject;

        var monoSecond = from GameObject gameObject in carbonMonoxide
                        where gameObject.GetComponent<MoleculeMovement>().room == 2
                        select gameObject;

        NumR2 = hotSecond.Count() + coldSecond.Count() + monoSecond.Count();

        concentrationSecond = ((float)monoSecond.Count() / (hotSecond.Count() + coldSecond.Count())) * 100f;

        if (coldFirst.Count() != 0)
        {
            float temp = (float)hotFirst.Count() / coldFirst.Count();
            temp = 1f - (1f / (0.01f * Mathf.Pow(temp, 2) + 1f));
            Heater.carbonChance = temp * 100f;
            //Debug.Log("chance " + Heater.carbonChance);
        }
        else
        {
            Heater.carbonChance = 100f;
        }

    }

    public void Generate()
    {
        if (!generated)
        {
            int first = amount / 2;
            int second = amount - first;

            for (int i = 0; i < first; i++)
            {
                Vector3 position = new Vector3(spanPointMain.x, spanPointMain.y, spanPointMain.z);
                GameObject temp = Instantiate(moleculePrefab, position, Quaternion.identity);
                temp.GetComponent<MoleculeMovement>().SetInitialTemperature(initialTemperature);
                temp.GetComponent<MoleculeMovement>().room = 1;
                coldAir.Add(temp);
            }
            for (int i = 0; i < second; i++)
            {
                Vector3 position = new Vector3(spanPointSecond.x, spanPointSecond.y, spanPointSecond.z);
                GameObject temp = Instantiate(moleculePrefab, position, Quaternion.identity);
                temp.GetComponent<MoleculeMovement>().SetInitialTemperature(initialTemperature);
                temp.GetComponent<MoleculeMovement>().room = 2;
                coldAir.Add(temp);
            }
            generated = true;
        }
    }

    public void SetInitialTemperature(string value)
    {
        initialTemperature = float.Parse(value);
    }

    public void SetNumberOfMolecules(string value)
    {
        amount = int.Parse(value);
    }

    public bool GetGeneratedStatus()
    {
        return generated;
    }
}
