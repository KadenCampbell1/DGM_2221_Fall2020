using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public void OnLook(Vector3Data obj)
    {
        transform.LookAt(obj.value);
        var rotationDirection = transform.eulerAngles;
        rotationDirection.x = 0;
        rotationDirection.y -= 90f;
        transform.rotation = Quaternion.Euler(rotationDirection);
    }
    
    public void ObjOnLook(Transform obj)
    {
        transform.LookAt(obj);
        var rotationDirection = transform.eulerAngles;
        rotationDirection.x = 0;
        rotationDirection.y -= 90f;
        transform.rotation = Quaternion.Euler(rotationDirection);
    }
}
