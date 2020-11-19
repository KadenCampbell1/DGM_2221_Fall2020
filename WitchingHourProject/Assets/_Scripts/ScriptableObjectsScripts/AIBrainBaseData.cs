using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu]
public class AIBrainBaseData : ScriptableObject
{
    public float health, speed, rotateSpeed, damage;
    public bool canShoot, canPatrol, canHunt;
    public Material material;
    public Mesh mesh;
    public List<Transform> patrolPoints;
    public GameObject artPrefab;
    
    private int i = 0;
    
    private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private WaitForSeconds wfs = new WaitForSeconds(2f);
    

    public virtual IEnumerator Patrol(NavMeshAgent agent)
    {
        canPatrol = true;
        canHunt = false;
        while (canPatrol)
        {
            yield return wffu;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                yield return wfs;
                agent.destination = patrolPoints[i].position;
                i = (i + 1) % patrolPoints.Count;
            }
        }
    }

    public virtual IEnumerator Hunt(NavMeshAgent agent, Transform obj)
    {
        canHunt = true;
        canPatrol = false;
        while (canHunt)
        {
            yield return wffu;
            agent.destination = obj.position;
        }
    }

}
