using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
    public LayerMask mouseClickLayer;
    public UnityEvent setPositionFromValueEvent, setValueFromPositionEvent;

    
    public void AddValueToValue(Vector3Data obj)
    {
        value += obj.value;
    }
    
    public void SetValueFromPosition(Transform objPosition)
    {
        value = objPosition.position;
        setValueFromPositionEvent.Invoke();
    }
    
    public void SetPositionFromValue(Transform objPosition)
    {
        objPosition.position = value;
        setPositionFromValueEvent.Invoke();
    }

    public void SetValueFromRotation(Transform obj)
    {
        value = obj.eulerAngles;
    }

    public void SetValueFromMousePosition(Camera cam)
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 1500f, mouseClickLayer))
        {
            value = hit.point;
        }
    }
}
