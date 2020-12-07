using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstancerBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> objList;
    public float holdTime = 0.5f;
    public bool canLoop = false;
    public int instanceCount = 1;

    private int counter = 0, iCounter = 0;
    private WaitForSeconds wfs;
    
    public UnityEvent startEvent, onCallEvent, restartEvent;
    
    private void Start()
    {
        wfs = new WaitForSeconds(holdTime);
        startEvent.Invoke();
    }

    public void CanLoopTrue()
    {
        canLoop = true;
    }

    public void CanLoopFalse()
    {
        canLoop = false;
    }
    
    public void StartLoopEvents()
    {
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

    public void InstanceList()
    {
        var location = transform.position;
        var rotation = transform.rotation;
        var newObj = Instantiate(objList[iCounter], location, rotation);
        iCounter = (iCounter + 1) % objList.Count;
    }
    
    public void InstanceList(Vector3Data obj)
    {
        var location = transform.position;
        var rotation = transform.rotation;
        var newObj = Instantiate(objList[iCounter], location, Quaternion.Euler(obj.value));
        iCounter = (iCounter + 1) % objList.Count;
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
        restartEvent.Invoke();
    }
}
