using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
* Permite manejar las transiciones de los paneles iniciales del juego.
* Se incluyen también sonidos para los botones que llaman a los métodos.
* Autor: Jacqueline Zavala.
*/


public class Transiciones : MonoBehaviour
{
    // VARIABLES
    public GameObject panelContexto1;
    public GameObject panelContexto2;
    public GameObject panelContexto3;
    public GameObject panelContexto4;
    public GameObject panelAyuda;
    public GameObject panelAyudaCopiar;
    public static AudioSource sonidoClic;
    private int panelActual;
    private GameObject[] paneles;

    void Start()
    {
        // Crea el arreglo de paneles
        paneles = new GameObject[]{panelContexto1, panelContexto2, panelContexto3, panelContexto4};
        panelActual = 0;
        // Cambia el timescale a 0 dado que se iniciarán los paneles y el tiempo no debe comenzar a correr.
        Time.timeScale = 0;   
    }

    public void Siguiente()
    {
        // Se pone el efecto de click.
        sonidoClic.Play();
        // Desactivamos el panel actual.
        paneles[panelActual].SetActive(false);
        if(panelActual+1 == 4)
        {
            // Si es el último panel, desactivarlo y cambiar el valor del timescale a 1
            // para que el tiempo comience a correr porque el juego va a comenzar
            paneles[panelActual].SetActive(false);
            Time.timeScale = 1;
            panelActual = 0;
            return;
        }
        // Si no es el último, simplemente le sumamos uno y activamos el siguiente.
        panelActual += 1;
        paneles[panelActual].SetActive(true);
    }

    public void Volver()
    {
        // Efecto de click
        sonidoClic.Play();
        if(panelActual == 0)
        {
            SceneManager.LoadScene("Mapa");    
        }
        else
        {
            paneles[panelActual].SetActive(false);
            panelActual -= 1;
            paneles[panelActual].SetActive(true);
        }

    }

   /* public void Ayuda()
    {
        // Efecto de click
        sonidoClic.Play();
        panelAyuda.SetActive(true);
        Time.timeScale = 0;
    }*/

    public void Ayuda()
    {
        sonidoClic.Play();
        if (!panelAyuda.activeSelf)
        {
            panelAyuda.SetActive(false);
        }
        else
        {
            panelAyudaCopiar.SetActive(false);
        }

        Time.timeScale = 1;
    }
    /*

    public void AyudaCopiar()
    {
        // Efecto de click
        sonidoClic.Play();
        panelAyudaCopiar.SetActive(true);
        Time.timeScale = 0;
        
    }
*/
    public void ContinuarJuego()
    {
        sonidoClic.Play();
        if (panelAyuda.activeSelf)
        {
            panelAyuda.SetActive(false);
        }
        else
        {
            panelAyudaCopiar.SetActive(false);
        }

        Time.timeScale = 1;
    }
}
