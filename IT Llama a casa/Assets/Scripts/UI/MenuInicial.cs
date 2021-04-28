using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    public void IniciaSesion()
    {
        SceneManager.LoadScene("MenuIniciarSesion");
    }

    public void Registro()
    {
        Application.OpenURL("http://localhost:8080/jugador/formularioRegistro#");
    }
    public void Salir()
    {
        Application.Quit();
    }
}