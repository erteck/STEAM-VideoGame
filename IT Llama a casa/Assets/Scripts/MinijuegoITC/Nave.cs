using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Permite determinar si la nave choca con un enemigo o
 * si llega al planeta de destino
 * Autores: Erick Bustos, David Rodriquez
 */
public class Nave : MonoBehaviour
{
    public static bool minijuegoCompletado = false;
    public static bool jugadormurio = false;
    public static int nivelActual = 1;
    public GameObject enemigosNivel1;
    public GameObject enemigosNivel2;
    public GameObject enemigosNivel3;
    public GameObject enemigosNivel4;
    public GameObject enemigosNivel5;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Destino"))
        {
            //NEXT LEVEL
            minijuegoCompletado = true;
            nivelActual += 1;

            if (nivelActual == 2)
            {
                enemigosNivel1.SetActive(false);
                enemigosNivel2.SetActive(true);
                
            }
            else if (nivelActual == 3)
            {
                enemigosNivel2.SetActive(false);
                enemigosNivel3.SetActive(true);
            }
            else if (nivelActual == 4)
            {
                enemigosNivel3.SetActive(false);
                enemigosNivel4.SetActive(true);
            }
            else if (nivelActual == 5)
            {
                enemigosNivel4.SetActive(false);
                enemigosNivel5.SetActive(true);
            }
            else if (nivelActual == 6)
            {
                SceneManager.LoadScene("Mapa");
            }
            
            // Detener lectura de intrucciones
            jugadormurio = true;
            
            // Reiniciar variables de toda la ejecución
            MoverPersonaje.readyNextInstruction = true;
            EjecutarCodigo.estoyAvanzando = false;
            EjecutarCodigo.estoyEsperando = false;
            EjecutarCodigo.estoyGirandoDerecha = false;
            EjecutarCodigo.estoyGirandoIzquierda = false;
            MoverPersonaje.whentoCount = true;
            transform.position = new Vector3((float) -8.48,(float) 4.49);
            transform.rotation =  Quaternion.Euler(0, 0, 0);
            
            // Permitir de nuevo la lectura de instrucciones
            jugadormurio = false;
        }
        else
        {

         
            //Dejar de dibujar la nave
            GetComponent<SpriteRenderer>().enabled = false;
            
            // Detener lectura de intrucciones
            jugadormurio = true;
            
            // Reiniciar variables de toda la ejecución
            MoverPersonaje.readyNextInstruction = true;
            EjecutarCodigo.estoyAvanzando = false;
            EjecutarCodigo.estoyEsperando = false;
            EjecutarCodigo.estoyGirandoDerecha = false;
            EjecutarCodigo.estoyGirandoIzquierda = false;
            MoverPersonaje.whentoCount = true;
            
            //Activar la explosión
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            // Llamar corrutina
            StartCoroutine(ContarExplosion());
            

        }
    }

    private IEnumerator ContarExplosion()
    {
        MoverPersonaje.readyNextInstruction = true; //Termina instrucción porque el jugador fue destruido
        
        // Espera medio segundo y desactiva la explosión
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
        // Espera medio segundo y regresa la nave al punto inicial
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector3((float) -8.48,(float) 4.49);
        transform.rotation =  Quaternion.Euler(0, 0, 0);
        
        // Permitir de nuevo la lectura de instrucciones
        jugadormurio = false;
        
        //Dibujar la nave de nuevo
        GetComponent<SpriteRenderer>().enabled = true;
        
    }
    
}
