using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirGenerator : MonoBehaviour
{
    public GameObject moleculePrefab;    
    public Vector3 minValues;
    public Vector3 maxValues;
    public int amount = 100;

    private bool generate = true;
    private ArrayList molecules;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && generate)
        {
            molecules = new ArrayList();
            for (int i = 0; i < amount; i++)
            {
                Vector3 position = new Vector3(Random.Range(minValues.x, maxValues.x), Random.Range(minValues.y, maxValues.y), Random.Range(minValues.z, maxValues.z));
                molecules.Add(Instantiate(moleculePrefab, position, Quaternion.identity));
            }
            generate = false;
        }
    }
}
