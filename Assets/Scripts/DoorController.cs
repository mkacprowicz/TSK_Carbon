using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public GameObject RoomChanger1;
    public GameObject RoomChanger2;

    bool IsOpen = false;

    public void OpenCloseDoor()
    {
        if (Door != null)
        {
            if (IsOpen)
            {
                Door.transform.Rotate(new Vector3(0, -90, 0));
                IsOpen = false;
                RoomChanger1.SetActive(false);
                RoomChanger2.SetActive(false);
            }
            else
            {
                Door.transform.Rotate(new Vector3(0, 90, 0));
                IsOpen = true;
                RoomChanger1.SetActive(true);
                RoomChanger2.SetActive(true);
            }
        }
    }
}
