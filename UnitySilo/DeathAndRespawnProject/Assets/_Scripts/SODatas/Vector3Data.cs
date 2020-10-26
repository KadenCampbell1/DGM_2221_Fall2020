using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void SetValueFromData(Vector3Data data)
    {
        value = data.value;
    }

    public void SetValueFromPosition(Transform objPosition)
    {
        value = objPosition.position;
    }
    
    public void SetPositionFromValue(Transform objPosition)
    {
        objPosition.position = value;
    }
}
