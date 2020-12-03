using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttachOnTriggerBehaviour : MonoBehaviour
{
    public UnityEvent onPlatformEvent, offPlatformEvent;
    public IDData idObj;
    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<IDHolderBehaviour>();
        if (otherID == null) return;

        if (idObj == otherID.idObj)
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
