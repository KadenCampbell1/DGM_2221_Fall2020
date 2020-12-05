using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
    public UnityAction action;
    public UnityAction<FloatData> floatDataAction;
    public UnityAction<Transform> transformAction;
    public UnityAction<BoxCollider> colliderAction;

    public void Raise()
    {
        action?.Invoke();
    }

    public void Raise(FloatData obj)
    {
        floatDataAction?.Invoke(obj);
    }
    
    public void Raise(Transform obj)
    {
        transformAction?.Invoke(obj);
    }

    public void Raise(BoxCollider obj)
    {
        colliderAction?.Invoke(obj);
    }
}
