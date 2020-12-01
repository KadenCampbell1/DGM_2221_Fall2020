using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AIStatesData : ScriptableObject
{
    public enum floatName
    {
        health, 
        speed, 
        rotateSpeed, 
        damage, 
        baseOffset, 
        timer
    }

    public floatName value;

    public void AssignHealthState()
    {
        value = floatName.health;
    }
    
    public void AssignSpeedState()
    {
        value = floatName.speed;
    }
    
    public void AssignRotateSpeedState()
    {
        value = floatName.rotateSpeed;
    }
    
    public void AssignDamageState()
    {
        value = floatName.damage;
    }
    
    public void AssignBaseOffsetState()
    {
        value = floatName.baseOffset;
    }
    
    public void AssignTimerState()
    {
        value = floatName.timer;
    }
}
