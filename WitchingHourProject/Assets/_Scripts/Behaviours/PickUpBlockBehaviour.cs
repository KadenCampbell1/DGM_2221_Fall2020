using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBlockBehaviour : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            transform.parent = other.transform;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            transform.parent = null;
        }
    }
}
