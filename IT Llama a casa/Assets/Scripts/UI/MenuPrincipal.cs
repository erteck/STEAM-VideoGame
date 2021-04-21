using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Permite darle funcionalidades a los componentes del menú
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/

public class MenuPrincipal : MonoBehaviour
{
    //MÉTODOS
    public void Jugar()
    {
        //Función que le otorgará la posibilidad de iniciar el juego al componente que se le asigne
        SceneManager.LoadScene("Mapa");
    }

    public void Salir()
    {
        //Función que le otorgará la posibilidad de salirse de la aplicación (juego) al componente que se le asigne
        Application.Quit();
    }

    public void Regresar()
    {
        SceneManager.LoadScene("MenuIniciarSesion");
    }
}
