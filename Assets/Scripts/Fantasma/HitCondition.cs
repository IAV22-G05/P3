using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/*
 * Devuelve Success cuando el fantasma ha sido golpeado
 */
public class HitCondition : Conditional
{
    GameBlackboard blackboard;

    public override void OnAwake()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public override TaskStatus OnUpdate()
    {
        if (blackboard.hited)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
