using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Events;

public class AIShootBehaviour : MonoBehaviour
{
    public TurretBehaviour lookAt;
    public InstancerBehaviour instance;
    public Vector3Data playerPositionData;
    public AIBrainBaseData aiBrain;
    public bool AITriggered, canShoot;
    public float holdtime = 1f;
    public UnityEvent onTriggerEnterEvent;

    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private WaitForSeconds wfs;

    private void Start()
    {
        wfs = new WaitForSeconds(holdtime);
        canShoot = aiBrain.canShoot;
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent.Invoke();
        lookAt.OnLook(playerPositionData);
        AITriggered = true;
        StartCoroutine(OnAIShoot());
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return new WaitForSeconds(5f);
        AITriggered = false;
    }

    private IEnumerator OnAIShoot()
    {
        if (!canShoot) yield break;
        while (AITriggered)
        {
            instance.Instance(playerPositionData);
            yield return wfs;
        }

        yield return wffu;
    }
}
