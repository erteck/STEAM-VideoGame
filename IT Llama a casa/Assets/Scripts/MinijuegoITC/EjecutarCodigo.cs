using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
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
    
    // Variables que permiten a MoverPersonaje.cs determinar qué tipo de movimiento se está llevando a cabo
    public static Boolean estoyAvanzando = false;
    public static Boolean estoyEsperando = false;
    public static Boolean estoyGirandoIzquierda = false;
    public static Boolean estoyGirandoDerecha = false;
    
    // Variable de tiempo para instrucciones que tienen un inputfield
    public static int tiempo;
    
    // Referencia a la nave.
    public GameObject nave;
    
    // Referencia al botón de reinicio
    public GameObject botonReinicio;
    
    // Referencia al botón de eliminar línea de código
    public Button botoneliminar;
    
    // Referencia al botón Play
    public Button botonplay;

    private Coroutine cor;

    private bool noejecutar = false;

    public static int i;

    private int force;
    // Función asignada a botón Play
    public void ejecutaCodigo()
    {
        if (InsertaBloques.numBloque > 0)
        {
            // Se utiliza una corrutina para pausar la lectura del vector entre la ejecución
            //de animaciones
            Nave.lecturaInstrucciones = false;
            //forzar = 0;
            force = 0;
            StartCoroutine(Waiter());
        
            // Desactivamos la interactividad de los botones
            botoneliminar.interactable = false;
            botonplay.interactable = false;
        }

    }

    //Corrutina que hace la lectura de las instrucciones y las pausas entre animaciones
    private IEnumerator Waiter()
    {
        Debug.Log("ACABO DE EMPEZAR DE NUEZZZZ");
        //foreach (var bloque in instrucciones)
        for(i = force; i < instrucciones.Count ;i++)
        {
            Debug.Log(instrucciones[i][0].ToString());
            //Avanzar n espacios
            //if (bloque[0] == 1)
            if(instrucciones[i][0] == 1 & !noejecutar)
            {
                Debug.Log("Avanzar");
                //tiempo = bloque[1];
                tiempo = instrucciones[i][1];
                estoyAvanzando = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
                

            }
            // Esperar n segundos
            //else if (bloque[0] == 2)
            if(instrucciones[i][0] == 2 & !noejecutar)
            {
                Debug.Log("Parar");
                //tiempo = bloque[1];
                tiempo = instrucciones[i][1];
                estoyEsperando = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
            }
            //Girar a la izquierda
            //else if (bloque[0] == 3)
            if(instrucciones[i][0] == 3 & !noejecutar)
            {
                Debug.Log("GirIZQ");
                estoyGirandoIzquierda = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
            }
            //Girar a la derecha
            //else if (bloque[0] == 4)
            if(instrucciones[i][0] == 4 & !noejecutar)
            {
                Debug.Log("GirDer");
                estoyGirandoDerecha = true;
                yield return new WaitUntil(() => MoverPersonaje.readyNextInstruction);
            }
            
            // Si el jugador murió o pasó exitosamente el nivel dejar de leer el vector de instrucciones
            if (Nave.lecturaInstrucciones)
            {
                Debug.Log("SIIIIIIIIIIIIIIIIIIIIII");
                MoverPersonaje.readyNextInstruction = false;
                // Reactivar botones
                botoneliminar.interactable = true;
                botonplay.interactable = true;
                noejecutar = true;
                //Nave.lecturaInstrucciones = false;
                //yield return null;
                //StartCoroutine(Waiter());


            }
            
            Debug.Log("ITERACION");
            MoverPersonaje.readyNextInstruction = false;
            
        }
        // Si no se completó el nivel, despliega el botón de reinicio
        if (!Nave.nivelCompletado & !(nave.transform.position.x == -8.48))
        {
            botonReinicio.gameObject.SetActive(true);
            
        }
        
        // Reactivar botónes
        botoneliminar.interactable = true;
        botonplay.interactable = true;
        
    }
    
}
