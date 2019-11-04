using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirGenerator : MonoBehaviour
{
    public GameObject moleculePrefab;    
    public int amount = 1000;

    public Vector3 spanPointMain = new Vector3(0f, 0.5f, 1f);
    public Vector3 spanPointSecond = new Vector3(0f, 0.5f, -1f);
    public Vector3 spanPointOutside = new Vector3(0f, 0.5f, -2f);

    //public float density;
    public float concentration;

    private bool generate = true;

    public ArrayList coldAir;
    public ArrayList hotAir;
    public ArrayList carbonMonoxide;
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
        if (Input.GetKeyDown(KeyCode.Space) && generate)
        {            
            for (int i = 0; i < amount; i++)
            {
                Vector3 position = new Vector3(spanPointMain.x, spanPointMain.y, spanPointMain.z);
                coldAir.Add(Instantiate(moleculePrefab, position, Quaternion.identity));
            }
            generate = false;
        }


        concentration = (float)carbonMonoxide.Count / amount * 100f;

        if(coldAir.Count != 0)
        {
            if ((float)hotAir.Count / coldAir.Count > 0.75f)
            {
                Heater.carbonChance = 50f;
            }
        }
    }
}
