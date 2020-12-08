using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class BoolData : ScriptableObject
{
    public bool value;
    public UnityEvent trueEvent;

    public void SetValue(bool obj)
    {
        value = obj;
    }

    public void CheckIfTrue()
    {
        if (value)
        {
            trueEvent.Invoke();
        }
    }
}
