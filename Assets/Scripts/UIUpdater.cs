using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public GameObject TextRoom1;
    public GameObject TextRoom2;

    public GameObject AirGenerator;

    public GameObject UiObject1;
    public GameObject UiObject2;
    public GameObject UiObject3;
    public GameObject UiObject4;
    public GameObject UiObject5;

    bool AreActive = true;


    // Start is called before the first frame update
    void Start()
    {
        TextRoom1.GetComponent<UnityEngine.UI.Text>().text = "0.0%";
        TextRoom1.GetComponent<UnityEngine.UI.Text>().color = Color.black;
        TextRoom2.GetComponent<UnityEngine.UI.Text>().text = "0.0%";
        TextRoom2.GetComponent<UnityEngine.UI.Text>().color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (AirGenerator.GetComponent<AirGenerator>().GetGeneratedStatus() && AreActive)
        {
            UiObject1.SetActive(false);
            UiObject2.SetActive(false);
            UiObject3.SetActive(false);
            UiObject4.SetActive(false);
            UiObject5.SetActive(false);

            AreActive = false;
        }

        float R1 = AirGenerator.GetComponent<AirGenerator>().concentrationFirst;
        float R2 = AirGenerator.GetComponent<AirGenerator>().concentrationSecond;

        if (float.IsNaN(R1))
        {
            R1 = 0;
        }

        if (float.IsNaN(R2))
        {
            R2 = 0;
        }

        if (R1 > 0.00001f)
            R1 = Mathf.Round(R1 * 100.0f) / 100.0f;
        else
            R1 = 0;

        if (R2 > 0.00001f)
            R2 = Mathf.Round(R2 * 100.0f) / 100.0f;
        else
            R2 = 0;

        TextRoom1.GetComponent<UnityEngine.UI.Text>().text = R1.ToString() + "%";
        TextRoom2.GetComponent<UnityEngine.UI.Text>().text = R2.ToString() + "%";


        if (R1 >= 0.5f)
        {
            TextRoom1.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }
        else if (R1 < 0.5f && R1 > 0.11f)
        {
            TextRoom1.GetComponent<UnityEngine.UI.Text>().color = Color.Lerp(Color.yellow, Color.red, 0.75f);
        }
        else if (R1 < 0.11f && R1 > 0.04f)
        {
            TextRoom1.GetComponent<UnityEngine.UI.Text>().color = Color.Lerp(Color.yellow, Color.red, 0.5f);
        }
        else if (R1 < 0.04f && R1 > 0.02f)
        {
            TextRoom1.GetComponent<UnityEngine.UI.Text>().color = Color.Lerp(Color.yellow, Color.red, 0.25f);
        }
        else if (R1 < 0.02f && R1 > 0.005f)
        {
            TextRoom1.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;
        }
        else
        {
            TextRoom1.GetComponent<UnityEngine.UI.Text>().color = Color.black;
        }

        if (R2 >= 0.5f)
        {
            TextRoom2.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }
        else if (R2 < 0.5f && R2 > 0.11f)
        {
            TextRoom2.GetComponent<UnityEngine.UI.Text>().color = Color.Lerp(Color.yellow, Color.red, 0.75f);
        }
        else if (R2 < 0.11f && R2 > 0.04f)
        {
            TextRoom2.GetComponent<UnityEngine.UI.Text>().color = Color.Lerp(Color.yellow, Color.red, 0.5f);
        }
        else if (R2 < 0.04f && R2 > 0.02f)
        {
            TextRoom2.GetComponent<UnityEngine.UI.Text>().color = Color.Lerp(Color.yellow, Color.red, 0.25f);
        }
        else if (R2 < 0.02f && R2 > 0.005f)
        {
            TextRoom2.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;
        }
        else
        {
            TextRoom2.GetComponent<UnityEngine.UI.Text>().color = Color.black;
        }
    }
}
