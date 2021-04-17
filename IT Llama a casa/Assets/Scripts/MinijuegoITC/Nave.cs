using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public GameObject botonReiniciar;
    public static bool minijuegoCompletado = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Destino"))
        {
            //NEXT LEVEL
            minijuegoCompletado = true;
        }
        else
        {
            //EXPLODE
            botonReiniciar.gameObject.SetActive(true);
        }
    }
    
    
}

