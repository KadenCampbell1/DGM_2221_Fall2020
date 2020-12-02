using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftBlocksBehaviour : MonoBehaviour
{
    public BoxCollider riftCollider;
    private void Start()
    {
        riftCollider.isTrigger = false;
    }

    private void Update()
    {
        riftCollider.isTrigger = false;
    }
}
