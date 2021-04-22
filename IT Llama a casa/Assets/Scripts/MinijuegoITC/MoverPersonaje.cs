using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
 * Ejecuta los movimientos correspondientes de la nave de acuerdo
 * a las instrucciones introducidas por el usuario
 * Autor: Erick Bustos
 */
public class MoverPersonaje : MonoBehaviour
{
    // Referencia al transform de la nave
    private Transform transform;
    // Variable que indica cuando ya se terminó de ejecutar un movimiento
    public static bool readyNextInstruction = false;
    // Variable que permite determinar cuando activar las rutinas Espera y EsperaRotación
    public static bool whentoCount = true;
    
   
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    
    void Update()
    {
        // Avanzar
        if (EjecutarCodigo.estoyAvanzando)
        {
            Debug.Log("EntreIFAvanzar");
            transform.Translate(Vector3.right * Time.deltaTime);
            if (whentoCount)
            {
                StartCoroutine(Espera(EjecutarCodigo.tiempo));
                whentoCount = false;
            }
            
        }
        // Esperar
        else if (EjecutarCodigo.estoyEsperando)
        {
            Debug.Log("EntreIFEsperar");
            if (whentoCount)
            {
                StartCoroutine(Espera(EjecutarCodigo.tiempo));
                whentoCount = false;
            }
        }
        // Girar Derecha
        else if (EjecutarCodigo.estoyGirandoDerecha)
        {
            Debug.Log("EntreGirarDerecha");
            transform.Rotate(0,0,Time.deltaTime * -45);
            if (whentoCount)
            {
                StartCoroutine(EsperaRotacion());
                whentoCount = false;
            }
            
        }
        // Girar Izquierda
        else if (EjecutarCodigo.estoyGirandoIzquierda)
        {
            Debug.Log("EntreGirarIzq");
            transform.Rotate(0,0,Time.deltaTime * 45);
            if (whentoCount)
            {
                StartCoroutine(EsperaRotacion());
                whentoCount = false;
            }
        }

    }

    // Rutina que cuenta el tiempo que deben ejecutarse las instrucciones avanzar y parar
    // y al terminar, frena su ejecución y permite ejecutar una nueva intrucción
    private IEnumerator Espera(int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        EjecutarCodigo.estoyAvanzando = false;
        EjecutarCodigo.estoyEsperando = false;
        readyNextInstruction = true;
        whentoCount = true;
    }
    
    // Rutina que cuenta el tiempo que deben ejecutarse las instrucciones relacionadas con girar
    // y al terminar, frena su ejecución y permite ejecutar una nueva intrucción
    private IEnumerator EsperaRotacion()
    {
        yield return new WaitForSeconds(2f);
        EjecutarCodigo.estoyGirandoDerecha = false;
        EjecutarCodigo.estoyGirandoIzquierda = false;
        readyNextInstruction = true;
        whentoCount = true;
    }
}
