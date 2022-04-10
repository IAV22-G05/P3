using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionGolpe : MonoBehaviour
{
    GameBlackboard blackboard;

    public void Start()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            blackboard.hited = true;
            Debug.Log("Han golpeado al fantasma");
        }
    }
}