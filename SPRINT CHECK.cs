using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintingStatusPrinter : MonoBehaviour
{
    void Update()
    {
        if (PlayerMovement.isSprinting)
        {
            Debug.Log("THE ROOMBA IS ZOOMING");
        }
    }
}
