﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UCM.IAV.Movimiento;

/*
 * Tiene una referencia a todas las variables del mundo necesarias para que otros objetos tengan acceso a estas
 * Referencia a las habitaciones, a la posición (parcial) del fantasma o la cantante
 * Si el piano o el fantasma ha sido golpeado
 * Si la puerta de la celda está cerrada
 */

public class GameBlackboard : MonoBehaviour
{
    public GameObject musicRoom;
    public GameObject celda;
    public GameObject singer;
    public GameObject stage;
    public GameObject basement;
    public GameObject backStage;
    public GameObject westLever;
    public GameObject eastLever;
    public GameObject piano;
    public GameObject puerta;
    public GameObject[] randomSitios;
    public bool imprisoned { get; set; }
    public bool captured { get; set; }

    public bool isGhostInSotano { get; set; }

    public bool pianoed { get { return piano.GetComponent<ControlPiano>().tocado; } }
    public bool hited;
    
    public bool gate { get; set; }

    void Awake()
    {
        captured = false;
        imprisoned = false;
        gate = false;
        hited = false;
    }

    private void Update()
    {
        imprisoned = singer.GetComponent<Cantante>().EstaEnCelda();
    }

    // Permite al fantasma saber a qué palanca debería ir
    public GameObject nearestLever(GameObject go) 
    {
        if ((westLever.transform.position - go.transform.position).magnitude > (eastLever.transform.position - go.transform.position).magnitude
            && !eastLever.transform.GetChild(0).GetComponent<ControlPalanca>().caido)
            return eastLever;
        else if (!westLever.transform.GetChild(0).GetComponent<ControlPalanca>().caido)
            return westLever;
        else
            return null;
    }


    // Permite al fantasma escoger un lugar aleatorio para buscar a la cantante
    public GameObject getRandomSitio()
    {
        GameObject go = randomSitios[Random.Range(0, randomSitios.Length)];
        Debug.Log(go.name);
        return go;
    }
}
