using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
Monitorea todos los comportamientos del HUD
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/

public class HUD : MonoBehaviour
{
    //VARIABLES
    public Image Vida1;          //Corazones del personaje
    public Image Vida2;
    public Image Vida3;
    public Text Numpiezas;      //Texto que indica el número de piezas recolectadas
    public static HUD instance;  //Referencia a la clase HUD

    //MÉTODOS
    private void Awake()
    {
        //Se hace el enlace entre el script y el HUD
        instance = this;
    }

    public void ActualizarVidas()
    {
        //Actualiza los corazones del HUD basándose en las vidas que tiene el personaje
        int vidas = EstadoPJ.instance.vidas;
        if(vidas == 2)
        {
            Vida3.enabled = false;
        }
        else if(vidas == 1)
        {
            Vida2.enabled = false;
        }
        else if(vidas == 0)
        {
            Vida1.enabled = false;
            SceneManager.LoadScene("MenuPrincipal");//Nos vamos al menú principal al morir
        }
    }

    public void ActualizarPiezas()
    {
        //Función que actualiza el texto que indica cuantas piezas lleva recolectadas el personaje
        Numpiezas.text = EstadoPJ.instance.piezas.ToString();
    }
}
