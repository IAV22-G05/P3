using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;


/*
 * Devuelve Success si la cantante esta en el escenario o bambalinas (haciendo el show)
 */
public class ScenarioCondition : Conditional
{
    GameBlackboard blackboard;
    public override void OnAwake()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public override TaskStatus OnUpdate()
    {
        // Si esta descansando o cantando es que esta haciendo el show
        // Consideramos que el fantasma una vez que escucha a la cantante, aunque vuelva a las bambalinas sigue 
        // yendo hacia ella
        if (blackboard.singer.GetComponent<Cantante>().inicioCanto)
        {
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;
    }
}
