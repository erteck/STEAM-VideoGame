using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permite determinar si la nave choca con un enemigo o
 * si llega al planeta de destino
 * Autores: Erick Bustos, David Rodriquez
 */
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
            //Dejar de dibujar la nave
            GetComponent<SpriteRenderer>().enabled = false;
            //Activar la explosión
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // Llamar corrutina
            StartCoroutine(ContarExplosion());

        }
    }

    private IEnumerator ContarExplosion()
    {
        // Espera medio segundo y desactiva la explosión
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        // Espera medio segundo y regresa la nave al punto inicial
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector3((float) -8.48,(float) 4.49);
        transform.rotation =  Quaternion.Euler(0, 0, 0);
        GetComponent<SpriteRenderer>().enabled = true;
    }
    
}

