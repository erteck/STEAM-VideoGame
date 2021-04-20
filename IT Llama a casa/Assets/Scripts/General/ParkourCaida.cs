using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Detecta la colisión del jugador con la "lava"" del parkour. 
Regresa al jugador al inicio del parkour
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/
public class ParkourCaida : MonoBehaviour
{
    //VARIABLES
    public float x;
    public float y;

    //MÉTODOS
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Función que se ejecuta si la "lava" colisiona con otro Collider
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector2(x, y);
            EstadoPJ.instance.vidas--;
            HUD.instance.ActualizarVidas();
        }
    }
}
