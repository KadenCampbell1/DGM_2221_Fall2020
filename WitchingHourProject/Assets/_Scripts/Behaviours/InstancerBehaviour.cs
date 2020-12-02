using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstancerBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public float holdTime = 0.5f, scaleIncrement = 1.25f;
    public bool canLoop = false;
    public int instanceCount = 1;
    public Vector3 scale;
    
    private int counter = 0;
    private WaitForSeconds wfs;
    
    public UnityEvent startEvent, onCallEvent;
    
    private void Start()
    {
        wfs = new WaitForSeconds(holdTime);
        scale = prefab.transform.localScale;
        startEvent.Invoke();
    }

    public void CanLoopFalse()
    {
        canLoop = false;
    }
    
    public void StartLoopEvents()
    {
        canLoop = true;
        StartCoroutine(CallInstanceEvent());
    }
    
    public void Instance()
    {
        var location = transform.position;
        var rotation = transform.rotation;
        var newObj = Instantiate(prefab, location, rotation);
    }
    
    public void Instance(Vector3Data rotationDirection)
    {
        var location = transform.position;
        var newObj = Instantiate(prefab, location, Quaternion.Euler(rotationDirection.value));
    }
    
    public void Instance(GameObject obj)
    {
        var location = obj.transform.position;
        var rotation = obj.transform.rotation;
        var newObj = Instantiate(obj, location, rotation);
    }
    
    public void Instance(Transform obj)
    {
        var location = obj.position;
        var rotation = obj.rotation;
        var newObj = Instantiate(prefab, location, rotation);
    }

    public void Instance(float obj, Vector3Data rotateDirection)
    {
        var location = transform.position;
        var rotation = rotateDirection.value;
        scale /= scaleIncrement;
        var newObj = Instantiate(prefab, location, Quaternion.Euler(rotation));
    }
    
    private IEnumerator CallInstanceEvent()
    {
        while (canLoop && counter < instanceCount)
        {
            onCallEvent.Invoke();
            counter++;
            yield return wfs;
        }
        canLoop = false;
        counter = 0;
    }
}
