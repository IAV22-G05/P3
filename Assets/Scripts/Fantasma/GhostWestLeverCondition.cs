using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/*
 * Devuelve Success cuando las luces est�n encendidas
 */
public class GhostWestLeverCondition : Conditional
{
    GameBlackboard blackboard;

    public override void OnAwake()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public override TaskStatus OnUpdate()
    {
        //Si no esta caida  pasamos a tirarla
        if (!blackboard.westLever.transform.GetChild(0).GetComponent<ControlPalanca>().caido)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
