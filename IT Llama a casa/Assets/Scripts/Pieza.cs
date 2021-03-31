using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Detecta la colisión del jugador con las piezas para su recolección
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/

public class Pieza : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Función que se ejecuta si la pieza colisiona con otro Collider
        if(other.gameObject.CompareTag("Player"))
        {
            //Si el game object que recolecta la moneda es el jugador entonces:
            GetComponent<SpriteRenderer>().enabled = false;   //Se deja de renderizar la pieza

            //Se destruye el objeto
            Destroy(gameObject, 0.4f);
        }
    }
}
