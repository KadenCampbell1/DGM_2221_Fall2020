﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
    
    public void SetValueFromPosition(Transform objPosition)
    {
        value = objPosition.position;
    }
    
    public void SetPositionFromValue(Transform objPosition)
    {
        objPosition.position = value;
    }

    public void SetValueFromRotation(Transform obj)
    {
        value = obj.eulerAngles;
    }

    public void SetValueFromMousePosition(Camera cam)
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            value = hit.point;
        }
    }
}
