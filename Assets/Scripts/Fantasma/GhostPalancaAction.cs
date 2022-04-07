﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de accionar una palanca de los candelabros (la mas cercana), cuando la alcanza devuelve Success
 */

public class GhostPalancaAction : Action
{
    NavMeshAgent agent;
    GameObject lever;
    GameBlackboard blackboard;
    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public override TaskStatus OnUpdate()
    {
        lever = blackboard.nearestLever(this.gameObject);
        if (lever == null)
            return TaskStatus.Success;
        var navHit = new NavMeshHit();
        NavMesh.SamplePosition(transform.position, out navHit, 2, NavMesh.AllAreas);
        agent.SetDestination(lever.transform.position);
        if (Vector3.SqrMagnitude(transform.position - lever.transform.position) < 1)
        {
            agent.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        else return TaskStatus.Running;
    }
}
