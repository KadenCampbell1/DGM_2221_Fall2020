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

    public void SetValue(float obj)
    {
        value = obj;
    }
    
    public void IncrementValue(float obj)
    {
        value += obj;

        if (value <= 0.0001f && value >= -0.0001f)
        {
            value = 0;
        }
    }
    
    public void SetImageFillAmount(Image image)
    {
        image.fillAmount = value;
    }
    
    
}
