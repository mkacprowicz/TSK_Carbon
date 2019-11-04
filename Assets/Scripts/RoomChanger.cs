using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour
{
    public int ToRoom = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Molecule"))
        {
            other.gameObject.GetComponent<MoleculeMovement>().changeRoom(ToRoom);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Molecule"))
        {
            other.gameObject.GetComponent<MoleculeMovement>().changeRoom(ToRoom);
        }
    }
}
