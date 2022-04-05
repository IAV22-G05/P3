using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/*
 * Devuelve Success cuando el piano haya sido tocado
 */
public class PianoCondition : Conditional
{
    GameBlackboard blackboard;

    public override void OnAwake()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public override TaskStatus OnUpdate()
    {
        if (blackboard.pianoed)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
