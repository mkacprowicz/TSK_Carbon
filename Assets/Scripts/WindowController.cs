using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public GameObject Window;

    bool IsOpen = false;

    public void OpenCloseWindow()
    {
        if (Window != null)
        {
            if (IsOpen)
            {
                Window.transform.Rotate(new Vector3(0, -90, 0));
                IsOpen = false;
            }
            else
            {
                Window.transform.Rotate(new Vector3(0, 90, 0));
                IsOpen = true;
            }
        }
    }
}
