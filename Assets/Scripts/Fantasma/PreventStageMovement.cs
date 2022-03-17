using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

/*
 * Accion de impedir pasar por el escenario al NavMeshAgent, devuelve Success
 */

public class PreventStageMovement : Action
{
    NavMeshAgent agent;

    public override void OnAwake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public override TaskStatus OnUpdate()
    {
        int a = agent.areaMask, b = 1 << NavMesh.GetAreaFromName("Escenario");
        agent.areaMask = (a | b) & (~a | ~b); // XOR
        return TaskStatus.Success;
    }
}
