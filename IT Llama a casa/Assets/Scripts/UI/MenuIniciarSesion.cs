using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIniciarSesion : MonoBehaviour
{
    public void Regresar()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void IniciarSesion()
    {
        //Aquí va el código que verifique los datos
    }
}
