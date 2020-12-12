using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ChangeShaderBehaviour : MonoBehaviour
{
    public Material originalMat, newMat;
    private MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void ChangeToNewMat()
    {
        renderer.material = newMat;
    }

    public void ChangeToOriginalMat()
    {
        renderer.material = originalMat;
    }
}
