using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class AIwithBrainBehaviour : MonoBehaviour
{
    public AIBrainBaseData brain;
    public AIStatesData stateData;
    
    private NavMeshAgent agent;
    private float namedValue, dataValue, health, speed, rotateSpeed, damage, baseOffset, timer;
    private bool canPatrol, canHunt;
    public UnityEvent aiDeath, bossSwitch;
    public GameAction gameAction, transformAction;

    private int i = 0;
    
    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private WaitForSeconds wfs;

    private void Start()
    {
        gameAction.floatDataAction += FloatDataHandler;
        transformAction.transformAction += StartHunt;
        agent = GetComponent<NavMeshAgent>();
        RefreshBools();
        health = brain.health;
        speed = brain.speed;
        rotateSpeed = brain.rotateSpeed;
        damage = brain.damage;
        baseOffset = brain.baseOffset;
        timer = brain.timer;
        
        agent.speed = speed;
        agent.angularSpeed = rotateSpeed;
        agent.baseOffset = baseOffset;
        wfs = wfs = new WaitForSeconds(timer);
        Instantiate<GameObject>(brain.artPrefab, this.transform);
        StartCoroutine(Patrol());
    }

    private void Update()
    {
        switch (stateData.value)
        {
            case AIStatesData.floatName.health:
                namedValue = health;
                break;
            case AIStatesData.floatName.speed:
                namedValue = speed;
                break;
            case AIStatesData.floatName.rotateSpeed:
                namedValue = rotateSpeed;
                break;
            case AIStatesData.floatName.damage:
                namedValue = damage;
                break;
            case AIStatesData.floatName.baseOffset:
                namedValue = baseOffset;
                break;
            case AIStatesData.floatName.timer:
                namedValue = timer;
                break;
        }
    }

    private void AssignNamedValue()
    {
        switch (stateData.value)
        {
            case AIStatesData.floatName.health:
                health = namedValue;
                if (health <= 2 && health >= 1.85f)
                {
                    bossSwitch.Invoke();
                }
                break;
            case AIStatesData.floatName.speed:
                speed = namedValue;
                break;
            case AIStatesData.floatName.rotateSpeed:
                rotateSpeed = namedValue;
                break;
            case AIStatesData.floatName.damage:
                damage = namedValue;
                break;
            case AIStatesData.floatName.baseOffset:
                baseOffset = namedValue;
                break;
            case AIStatesData.floatName.timer:
                timer = namedValue;
                break;
        }
    }

    private void FloatDataHandler(FloatData obj)
    {
        dataValue = obj.value;
    }
    
    public void IncrementFloat()
    {
        namedValue += dataValue;
        AssignNamedValue();
        if (health <= 0)
        {
            aiDeath.Invoke();
        }
    }

    public void RefreshBools()
    {
        canPatrol = brain.canPatrol;
        canHunt = brain.canHunt;
    }

    public void StartPatrol()
    {
        StartCoroutine(Patrol());
    }

    public void StartHunt(Transform obj)
    {
        StartCoroutine(Hunt(obj.transform));
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
    }

    private void OnDestroy()
    {
        gameAction.floatDataAction -= FloatDataHandler;
        transformAction.transformAction -= StartHunt;
    }
}
