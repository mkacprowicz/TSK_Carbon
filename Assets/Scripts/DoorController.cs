using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;

    bool IsOpen = false;

    public void OpenCloseDoor()
    {
        if (Door != null)
        {
            if (IsOpen)
            {
                Door.transform.Rotate(new Vector3(0, -90, 0));
                IsOpen = false;
            }
            else
            {
                Door.transform.Rotate(new Vector3(0, 90, 0));
                IsOpen = true;
            }
        }
    }
}
