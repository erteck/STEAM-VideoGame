using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
*Script que le da sus funcionalidades a la escena del inicio
* Autor: Erick Hernández
*/

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    public void IniciaSesion()
    {
        SceneManager.LoadScene("MenuIniciarSesion");
    }

    public void Registro()
    {
        Application.OpenURL("http://18.116.89.34:8080/jugador/formularioRegistro#");
    }
    public void Salir()
    {
        Application.Quit();
    }
}