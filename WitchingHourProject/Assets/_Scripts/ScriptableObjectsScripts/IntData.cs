using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    public UnityEvent setValueEvent;

    public void SetValue(int i)
    {
        value = i;
        setValueEvent.Invoke();
    }

    public void MultiplyValue(int i)
    {
        value *= i;
    }

    public void SetCameraPriority(CinemachineVirtualCamera vCamera)
    {
        vCamera.Priority = value;
    }
}
