using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Script que le otorga sus comportamientos a la escena de créditos
* Autores: David Rodríguez e Israel Sánchez
*/

public class Creditos : MonoBehaviour
{
    //MÉTODOS
    public void Regresar()
    {
        //Función asociada a un botón que regresa al jugador al menú principal
        SceneManager.LoadScene("MenuPrincipal");
    }
}
