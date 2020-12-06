using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Events;

public class AIShootBehaviour : MonoBehaviour
{
    // public TurretBehaviour lookAt;
    public InstancerBehaviour instance;
    public AIBrainBaseData aiBrain;
    public bool aiTriggered, canShoot, isBoss;
    public float holdtime = 0.6f;
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
        // lookAt.OnLook(playerPositionData);
        aiTriggered = true;
        StartCoroutine(OnAIShoot());
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        if (!isBoss)
        {
            yield return new WaitForSeconds(5f);
            aiTriggered = false;
        }
    }

    private IEnumerator OnAIShoot()
    {
        if (!canShoot) yield break;
        while (aiTriggered)
        {
            instance.Instance();
            yield return wfs;
        }

        yield return wffu;
    }
}
