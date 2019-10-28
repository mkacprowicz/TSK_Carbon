using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInDoorController : MonoBehaviour
{
    public GameObject HoleOpened;
    public GameObject HoleClosed;

    bool IsOpen = false;

    public void OpenCloseHole()
    {
        if (HoleOpened != null)
        {
            if (HoleClosed != null)
            {
                if (IsOpen)
                {
                    HoleClosed.SetActive(true);
                    HoleOpened.SetActive(false);
                    IsOpen = false;
                }
                else
                {
                    HoleOpened.SetActive(true);
                    HoleClosed.SetActive(false);
                    IsOpen = true;
                }
            }
        }
    }
}
