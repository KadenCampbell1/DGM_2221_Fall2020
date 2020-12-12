using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoobyTrapBehaviour : MonoBehaviour
{
    public GameAction floatActionHandler;
    public float damageValue;
    public UnityEvent causedDamageEvent;
    private bool wasTriggered;

    private void Start()
    {
        floatActionHandler.floatDataAction += CauseDamageToValue;
    }

    public void WasTriggeredTrue()
    {
        wasTriggered = true;
    }

    private void CauseDamageToValue(FloatData obj)
    {
        if (wasTriggered)
        {
            obj.IncrementValue(damageValue);
            causedDamageEvent.Invoke();
        }
    }

    private void OnDestroy()
    {
        floatActionHandler.floatDataAction -= CauseDamageToValue;
    }
}
