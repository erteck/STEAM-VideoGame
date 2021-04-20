using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
/*
 * Lee las instrucciones introducidas por el usuario y le indica al script MoverPersonaje
 * cuando ejecutarlas como animaciones
 * Autor: Erick Bustos
 */
public class EjecutarCodigo : MonoBehaviour
{
    // Arreglo con las intrucciones
    public static List<List<int>> instrucciones = new List<List<int>>(); 
    
    //Variables que permiten a MoverPersonaje.cs determinar qué tipo de movimiento se está llevando a cabo
    public static Boolean estoyAvanzando = false;
    public static Boolean estoyEsperando = false;
    public static Boolean estoyGirandoIzquierda = false;
    public static Boolean estoyGirandoDerecha = false;
    
    //Variable de tiempo para instrucciones que tienen un inputfield
    public static int tiempo;
    
    //Referencia al botón de reinicio
    public GameObject botonReinicio;
    
    // Función asignada a botón Play
    public void ejecutaCodigo()
    {
        // Se utiliza una corrutina para pausar la lectura del vector entre la ejecución
        //de animaciones
        StartCoroutine(Waiter());
        // Se crea un nuevo vector
        //instrucciones =  new List<List<int>>();
        
    }

    //Corrutina que hace la lectura de las instrucciones y las pausas
    private IEnumerator Waiter()
    {
        foreach (var bloque in instrucciones)
        {
            //Avanzar n espacios
            if (bloque[0] == 1)
            {
                Debug.Log("Avanzar");
                tiempo = bloque[1];
                estoyAvanzando = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
                

            }
            // Esperar n segundos
            else if (bloque[0] == 2)
            {
                Debug.Log("Parar");
                tiempo = bloque[1];
                estoyEsperando = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
            }
            //Girar a la izquierda
            else if (bloque[0] == 3)
            {
                Debug.Log("GirIZQ");
                estoyGirandoIzquierda = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
            }
            //Girar a la derecha
            else if (bloque[0] == 4)
            {
                Debug.Log("GirDer");
                estoyGirandoDerecha = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
            }

            if (Nave.jugadormurio)
            {
                Debug.Log("IF MURIO");
                MoverPersonaje.readyNextInstruction = false;
                yield break;

            }
            
            Debug.Log("ITERACION");
            MoverPersonaje.readyNextInstruction = false;
        }
        // Si no se completó el nivel, despliega el botón de reinicio
        if (!Nave.minijuegoCompletado)
        {
            botonReinicio.gameObject.SetActive(true);
        }
    }
    
}
