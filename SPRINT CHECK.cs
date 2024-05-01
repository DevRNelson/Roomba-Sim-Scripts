using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintingStatusPrinter : MonoBehaviour
{
    void Update()
    {
        if (RoombaMovement.isSprinting)
        {
            Debug.Log("THE ROOMBA IS ZOOMING THE ROOMBA IS ZOOMING HOLY SHIT");
        }
    }
}
