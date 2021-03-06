﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu]
public class StringListData : ScriptableObject
{
    public List<string> stringList;
    private string returnValue;
    public UnityEvent listStartEvent, listEndEvent;

    private int i;

    private void OnEnable()
    {
        i = 0;
    }

    public void SetiToZero()
    {
        i = 0;
    }

    public void GetNextString()
    {
        returnValue = stringList[i];
        i = (i + 1) % stringList.Count;
        if (i >= 1)
        {
            listStartEvent.Invoke();
        }
        if (i <= 0)
        {
            listEndEvent.Invoke();
        }
    }

    public void SetTextUIToValue(Text obj)
    {
        obj.text = returnValue;
    }
}
