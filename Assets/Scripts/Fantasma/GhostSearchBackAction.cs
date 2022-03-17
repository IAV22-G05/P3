using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de ir a las bambalinas, cuando llega devuelve Success
 */

public class GhostSearchBackAction : Action
{
    NavMeshAgent agent;
    GameObject backStage;

    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        backStage = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>().backStage;
    }

    public override TaskStatus OnUpdate()
    {
        var navHit = new NavMeshHit();
        NavMesh.SamplePosition(transform.position, out navHit, 2, NavMesh.AllAreas);
        if(agent.enabled)
            agent.SetDestination(backStage.transform.position);
        if ((navHit.mask & 1 << NavMesh.GetAreaFromName("Bambalinas")) != 0)
        {
            
            agent.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}