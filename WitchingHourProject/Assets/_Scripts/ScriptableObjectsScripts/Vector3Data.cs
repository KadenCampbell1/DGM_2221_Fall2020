using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;
    public UnityEvent setPositionFromValueEvent;

    
    public void AddValueToValue(Vector3Data obj)
    {
        value += obj.value;
    }
    
    public void SetValueFromPosition(Transform objPosition)
    {
        value = objPosition.position;
    }
    
    public void SetPositionFromValue(Transform objPosition)
    {
        setPositionFromValueEvent.Invoke();
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

    public void SetFollowOffsetCameraValue(CinemachineVirtualCamera vCamera)
    {
        
    }
}
