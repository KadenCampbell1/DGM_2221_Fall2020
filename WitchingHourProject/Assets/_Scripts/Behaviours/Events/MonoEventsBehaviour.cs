using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent onEnableEvent, onStartEvent;

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);
        onStartEvent.Invoke();
    }
}
