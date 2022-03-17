using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de ir al escenario, cuando llega devuelve Success
 */

public class GhostSearchStageAction : Action
{
    NavMeshAgent agent;
    GameObject stage;

    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        stage = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>().stage;
    }

    public override TaskStatus OnUpdate()
    {
        var navHit = new NavMeshHit();
        NavMesh.SamplePosition(transform.position, out navHit, 2, NavMesh.AllAreas);
        if(agent.enabled)
            agent.SetDestination(stage.transform.position);
        if ((navHit.mask & 1 << NavMesh.GetAreaFromName("Escenario")) != 0)
        {
            if (agent.enabled)
                agent.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}