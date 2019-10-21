using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInDoorController : MonoBehaviour
{
    public GameObject Hole;

    bool IsOpen = true;

    public void OpenCloseHole()
    {
        if (Hole != null)
        {
            if (IsOpen)
            {
                Hole.SetActive(false);
                IsOpen = false;
            }
            else
            {
                Hole.SetActive(true);
                IsOpen = true;
            }
        }
    }
}
