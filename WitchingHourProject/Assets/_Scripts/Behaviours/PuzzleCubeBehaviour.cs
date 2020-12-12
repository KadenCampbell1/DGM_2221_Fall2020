using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleCubeBehaviour : MonoBehaviour
{
    public float holdTime;
    public BoolData puzzleBool;
    public ChangeShaderBehaviour shaderBehaviour;
    private bool timerOn;

    private WaitForSeconds wfs;
    
    private IEnumerator StartTimer()
    {
        timerOn = true;
        wfs = new WaitForSeconds(holdTime);
        yield return wfs;
        timerOn = false;
    }

    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
        if (timerOn) return;
        puzzleBool.value = false;
        shaderBehaviour.ChangeToOriginalMat();
        gameObject.SetActive(false);
    }
}
