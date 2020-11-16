using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class StasisBehaviour : MonoBehaviour
{

    public BoolData stasisIncrementBool, stasisDecrementBool;
    public FloatData stasisCount, timer, maxValue, incrementValue, decrementValue;
    public UnityEvent valueIsZeroEvent, updateUIEvent;

    public void BeginEnums(string obj)
    {
        StartCoroutine(obj);
    }
    
    public IEnumerator DecrementValueRepeating()
    {
        while (stasisDecrementBool.value)
        {
            yield return new WaitForSeconds(timer.value);
            stasisCount.value -= decrementValue.value;

            if (stasisCount.value <= 0)
            {
                valueIsZeroEvent.Invoke();
                stasisCount.value = 0;
                stasisDecrementBool.value = false;
            }
            
            updateUIEvent.Invoke();
        }
    }

    public IEnumerator IncrementValueRepeating()
    {
        while (stasisIncrementBool.value)
        {
            yield return new WaitForSeconds(timer.value);
            stasisCount.value += incrementValue.value;

            if (stasisCount.value >= maxValue.value)
            {
                stasisCount.value = maxValue.value;
                stasisIncrementBool.value = false;
            }
            
            updateUIEvent.Invoke();
        }
    }
}
