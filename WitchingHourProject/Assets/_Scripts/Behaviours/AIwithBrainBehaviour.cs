using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIwithBrainBehaviour : MonoBehaviour
{
    public AIBrainBaseData brain;
    
    private NavMeshAgent agent;
    public bool canPatrol, canHunt;
    private float health, speed, rotateSpeed, damage, baseOffset, timer;

    private int i = 0;
    
    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private WaitForSeconds wfs;

    public GameObject obj;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        RefreshBools();
        health = brain.health;
        speed = brain.speed;
        rotateSpeed = brain.rotateSpeed;
        damage = brain.damage;
        baseOffset = brain.baseOffset;
        timer = brain.timer;
        wfs = wfs = new WaitForSeconds(timer);
        Instantiate<GameObject>(brain.artPrefab, this.transform);
        StartCoroutine(Patrol());
    }

    public void RefreshBools()
    {
        canPatrol = brain.canPatrol;
        canHunt = brain.canHunt;
    }

    private IEnumerator ChangeBools()
    {
        var newTime = new WaitForSeconds(timer * 2);
        yield return newTime;
        canPatrol =! canPatrol;
        canHunt = !canHunt;
    }

    public void StartRoutines()
    {
        StartCoroutine(ChangeBools());
    }

    private IEnumerator Patrol()
    {
        canPatrol = true;
        canHunt = false;
        while (canPatrol)
        {
            yield return wffu;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                yield return wfs;
                agent.destination = brain.patrolPoints[i].position;
                i = (i + 1) % brain.patrolPoints.Count;
            }
        }

        StartCoroutine(Hunt(obj.transform));
    }

    private IEnumerator Hunt(Transform obj)
    {
        canHunt = true;
        canPatrol = false;
        while (canHunt)
        {
            yield return wffu;
            agent.destination = obj.position;
        }

        StartCoroutine(Patrol());
    }
}
