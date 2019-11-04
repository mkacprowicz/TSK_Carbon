using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Molecule"))
        {
            other.gameObject.GetComponent<MoleculeMovement>().changeRoom();
        }
    }
}
