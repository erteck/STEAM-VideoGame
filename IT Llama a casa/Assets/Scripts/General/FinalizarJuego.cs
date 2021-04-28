using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Script que le otorga sus comportamientos a la escena de créditos
Autores: David Rodríguez, Israel Sánchez, Jacqueline Zavala y Erick Bustos
*/



public class FinalizarJuego : MonoBehaviour
{
    public static FinalizarJuego instance;
    //MÉTODOS
    public void RevisarPiezas()
    {
        if(CargarJugador.piezaIBT && CargarJugador.piezaITC)
        {
            PuntoGuardado.instance.PartidaCompletada();
            SceneManager.LoadScene("EscenaFinal");
        }

    }

    public void Awake()
    {
        instance = this;
    }
}
