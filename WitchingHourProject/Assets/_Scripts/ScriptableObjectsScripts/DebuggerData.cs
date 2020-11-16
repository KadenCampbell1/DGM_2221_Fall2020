using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DebuggerData : ScriptableObject
{
    public void OnDebug(string obj)
    {
        Debug.Log(obj);
    }
}
