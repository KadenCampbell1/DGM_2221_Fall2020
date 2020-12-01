using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
    public UnityAction action;
    public UnityAction<float> floatAction;
    public UnityAction<FloatData> floatDataAction;

    public void Raise()
    {
        action?.Invoke();
    }

    public void Raise(float obj)
    {
        floatAction?.Invoke(obj);
    }
    
    public void Raise(FloatData obj)
    {
        floatDataAction?.Invoke(obj);
    }
}
