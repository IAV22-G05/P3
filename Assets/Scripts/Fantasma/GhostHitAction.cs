using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de ir a las bambalinas, cuando llega devuelve Success
 */

public class GhostHitAction : Action
{
    NavMeshAgent agent;
    Cantante cantante;
    GameObject backStage;

    public override void OnAwake()
    {
        cantante = GameObject.FindGameObjectWithTag("Cantante").GetComponent<Cantante>();
        agent = GetComponent<NavMeshAgent>();
        backStage = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>().backStage;
    }

    public override TaskStatus OnUpdate()
    {
        agent.SetDestination(transform.position);
        if (cantante.capturada)
        {
            cantante.Liberada();
        }
        return TaskStatus.Success;
    }
}