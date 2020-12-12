using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleCubeMasterBehaviour : MonoBehaviour
{
    public GameObject reward;
    public BoolData obj, obj1, obj2, obj3, obj4, obj5;
    public UnityEvent allFalseEvent;
    private void Update()
    {
        if (obj.value && obj1.value && obj2.value && obj3.value && obj4.value && obj5.value)
        {
            reward.gameObject.SetActive(true);
            var b = reward == null;
        }
        
        if (!obj.value && !obj1.value && !obj2.value && !obj3.value && !obj4.value && !obj5.value)
        {
            allFalseEvent.Invoke();
        }
    }
}
