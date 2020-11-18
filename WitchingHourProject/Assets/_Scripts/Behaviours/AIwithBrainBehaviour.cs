using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class AIwithBrainBehaviour : MonoBehaviour
{
    public AIBrainBaseData brain;
    
    private NavMeshAgent agent;
    private MeshFilter filter;
    private MeshRenderer render;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        filter = GetComponent<MeshFilter>();
        render = GetComponent<MeshRenderer>();
        filter.mesh = brain.mesh;
        render.material = brain.material;
        brain.Patrol(agent);
    }
}
