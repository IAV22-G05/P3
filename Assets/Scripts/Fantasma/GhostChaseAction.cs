using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de seguir a la cantante, cuando la alcanza devuelve Success
 */

public class GhostChaseAction : Action
{
    NavMeshAgent agent;
    GameObject singer;

    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        singer = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>().singer;
    }

    public override TaskStatus OnUpdate()
    {
        agent.SetDestination(singer.transform.position);
        if (Vector3.SqrMagnitude(transform.position - singer.transform.position) < 1.5f)
        {
            agent.SetDestination(transform.position);
            singer.transform.parent = transform;
            singer.GetComponent<Cantante>().capturada = true;
            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}
