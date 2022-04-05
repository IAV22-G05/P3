using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/*
 * Devuelve Success cuando las luces estén encendidas
 */
public class GhostEastLeverCondition : Conditional
{
    GameBlackboard blackboard;

    public override void OnAwake()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public override TaskStatus OnUpdate()
    {
        if (!blackboard.eastLever.transform.GetChild(0).GetComponent<ControlPalanca>().caido)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
