using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttachOnTrigger : MonoBehaviour
{
    public UnityEvent onPlatformEvent, offPlatformEvent;
    private void OnTriggerEnter(Collider other)
    {
        var otherTag = other.CompareTag("Platform");
        if (otherTag)
        {
            transform.parent = other.transform;
        }
        onPlatformEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent = null;
        offPlatformEvent.Invoke();
    }
}
