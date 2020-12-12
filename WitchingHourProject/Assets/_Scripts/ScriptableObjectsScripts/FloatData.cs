using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;
    public UnityEvent lessThanZeroEvent, greaterThanOneEvent;

    public void SetValue(float obj)
    {
        value = obj;
    }
    
    public void IncrementValue(float obj)
    {
        value += obj;

        if (value >= 1)
        {
            greaterThanOneEvent.Invoke();
        }

        if (value <= 0.0001f && value >= -0.0001f)
        {
            value = 0;
        }

        if (value <= 0)
        {
            lessThanZeroEvent.Invoke();
        }
    }
    
    public void SetImageFillAmount(Image image)
    {
        image.fillAmount = value;
    }
    
    
}
