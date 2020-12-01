using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class AIBrainBaseData : ScriptableObject
{
    public float health, speed, rotateSpeed, damage, baseOffset, timer;
    public bool canShoot, canPatrol, canHunt;
    public List<Transform> patrolPoints;
    public GameObject artPrefab;
    
}
