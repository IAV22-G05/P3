using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;


/*
 * Devuelve Success cuando el fantasma ha sido golpeado
 */
public class HitCondition : Conditional
{
    GameBlackboard blackboard;
    NavMeshAgent agent;
    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public override TaskStatus OnUpdate()
    {
        if (blackboard.hited)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
