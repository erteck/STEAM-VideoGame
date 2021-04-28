using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

/*
* Permite manejar las transiciones de los paneles iniciales del juego.
* Autores: Jacqueline Zavala.
*/


public class Transiciones : MonoBehaviour
{
    public GameObject panelContexto1;
    public GameObject panelContexto2;
    public GameObject panelContexto3;
    public GameObject panelContexto4;
    
    private int panelActual;

    private GameObject[] paneles;



    void Start()
    {
        // Le asigna los paneles a la variable
        paneles = new GameObject[]{panelContexto1, panelContexto2, panelContexto3, panelContexto4};
        panelActual = 0;
        Time.timeScale = 0;
        
    }

    public void Siguiente()
    {
        paneles[panelActual].SetActive(false);
        if(panelActual+1 == 4)
        {
            paneles[panelActual-1].SetActive(false);
            Time.timeScale = 1;
            panelActual = 0;
            return;
        }
        panelActual += 1;
        paneles[panelActual].SetActive(true);
    }

    public void Volver(){

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
