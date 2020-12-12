using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class BoolData : ScriptableObject
{
    public bool value;
    public UnityEvent trueEvent, setValueEvent;

    public void SetValue(bool obj)
    {
        value = obj;
        setValueEvent.Invoke();
    }

    public void CheckIfTrue()
    {
        if (value)
        {
            trueEvent.Invoke();
        }
    }
}
