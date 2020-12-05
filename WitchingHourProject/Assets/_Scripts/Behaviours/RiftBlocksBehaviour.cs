using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftBlocksBehaviour : MonoBehaviour
{
    public BoxCollider riftCollider;
    public GameAction colliderAction;
    private WaitForFixedUpdate wffu;

    private void Start()
    {
        colliderAction.colliderAction += GrabCollider;
        wffu = new WaitForFixedUpdate();
    }

    private void GrabCollider(BoxCollider obj)
    {
        riftCollider = obj;
    }

    public void IsTriggerTrue()
    {
        riftCollider.isTrigger = true;
    }
    
    private void Update()
    {
        riftCollider.isTrigger = false;
    }
}
