using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script que se encarga de quitarle una vida al jugador cada que hace contacto con el tilemap del objeto al que está asignado
Autor: Israel Sánchez Miranda
*/

public class TilemapDañoRayo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        //Función que se ejecuta si el tilemap entra en contacto con otro collider
        if(other.gameObject.CompareTag("Player"))
        {
            EstadoPJ.instance.vidas--;
            HUD.instance.ActualizarVidas();
        }
    }
}
