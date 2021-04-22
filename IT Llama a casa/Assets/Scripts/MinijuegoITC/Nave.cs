using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Permite determinar si la nave choca con un enemigo o si llega al planeta de destino.
 * Al chocar con un enemigo lleva a cabo una animación de explosión y la regresa a su posición y rotacion inicial.
 * Al llegar al planeta de destino, activa los enemigos del nuevo nivel y regresa la nave a su
 * posición inicial
 * Autores: Erick Bustos, David Rodriquez
 */
public class Nave : MonoBehaviour
{
    // Variable auxiliar que permite a EjecutarCodido.cs desplegar el botón de reiniciar cuando es necesario
    public static bool nivelCompletado = false;
    
    // Variable auxiliar para determinar cuando dejar de leer las instrucciones del usuario
    public static bool lecturaInstrucciones = false;
    
    // Nivel Actual
    public static int nivelActual = 1;
    
    // Enemigos de cada nivel
    public GameObject enemigosNivel1;
    public GameObject enemigosNivel2;
    public GameObject enemigosNivel3;
    public GameObject enemigosNivel4;
    public GameObject enemigosNivel5;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cuando el jugador completa el nivel
        if (other.gameObject.CompareTag("Destino"))
        {
            // Actualizar nivel
            nivelCompletado = true;
            nivelActual += 1;

            // Cambiar de enemigos
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
            lecturaInstrucciones = true;
            
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
            lecturaInstrucciones = false;
        }
        else
        {
            MoverPersonaje.readyNextInstruction = true;
            // Detener lectura de intrucciones
            lecturaInstrucciones = true;
            //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            
            // Reiniciar variables de toda la ejecución
            
            EjecutarCodigo.estoyAvanzando = false;
            EjecutarCodigo.estoyEsperando = false;
            EjecutarCodigo.estoyGirandoDerecha = false;
            EjecutarCodigo.estoyGirandoIzquierda = false;
            MoverPersonaje.whentoCount = true;
            
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
        MoverPersonaje.readyNextInstruction = true; //Termina instrucción porque el jugador fue destruido
        
        // Espera medio segundo y desactiva la explosión
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
        // Espera medio segundo y regresa la nave al punto inicial
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector3((float) -8.48,(float) 4.49);
        transform.rotation =  Quaternion.Euler(0, 0, 0);
        
        // Permitir de nuevo la lectura de instrucciones
        //lecturaInstrucciones = false;
        
        //Dibujar la nave de nuevo
        GetComponent<SpriteRenderer>().enabled = true;
        
    }
    
}

