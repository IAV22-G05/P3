using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionCaptura : MonoBehaviour
{
    GameBlackboard blackboard;
    Cantante cantante;

    private void Start()
    {
        blackboard = GameObject.FindGameObjectWithTag("Blackboard").GetComponent<GameBlackboard>();
    }
    private void OnEnable()
    {
        cantante = GameObject.FindGameObjectWithTag("Cantante").GetComponent<Cantante>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cantante"))
        {
            blackboard.saved = true;
            cantante.salvada = true;
            Debug.Log("Has capturado a la cantante");
        }
    }

}