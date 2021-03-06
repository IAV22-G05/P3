using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de abrir la puerta de la celda, yendo hacia la palanca, cuando la alcanza devuelve Success
 */
public class GhostOpenDoorAction : Action
{
    NavMeshAgent agent;
    GameBlackboard blackboard;
    GameObject puerta;

    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
        puerta = blackboard.puerta;
    }

    public override TaskStatus OnUpdate()
    {
        agent.SetDestination(puerta.transform.position);
        if (Vector3.SqrMagnitude(transform.position - puerta.transform.position) < 1.5f)
        {
            agent.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
}
