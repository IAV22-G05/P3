using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de ir a una sala aleatoria, asignada por el Blackboard, cuando llega devuelve Success
 */

public class GhostSearchRandomAction : Action
{
    NavMeshAgent agent;
    GameObject randomSitio;

    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public override void OnStart()
    {
        randomSitio = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>().getRandomSitio();
    }

    public override TaskStatus OnUpdate()
    {
        var navHit = new NavMeshHit();
        NavMesh.SamplePosition(transform.position, out navHit, 2, NavMesh.AllAreas);
        if(agent.enabled)
            agent.SetDestination(randomSitio.transform.position);
        if (Vector3.SqrMagnitude(transform.position - randomSitio.transform.position) < 1.5f)
        {
            
            agent.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}