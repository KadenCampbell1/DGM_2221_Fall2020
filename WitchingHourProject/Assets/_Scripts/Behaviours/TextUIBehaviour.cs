using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextUIBehaviour : MonoBehaviour
{
    public string value;
    private Text obj;

    private void Start()
    {
        obj = GetComponent<Text>();
    }

    public void SetTextWithValue(FloatData fObj)
    {
        obj.text = value + fObj.value;
    }
}
