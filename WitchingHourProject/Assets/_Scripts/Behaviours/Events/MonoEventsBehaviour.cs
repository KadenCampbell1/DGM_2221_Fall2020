using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent onEnableEvent, onStartEvent;
    public float holdTime = 0.1f;

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(holdTime);
        onStartEvent.Invoke();
    }
    
}
