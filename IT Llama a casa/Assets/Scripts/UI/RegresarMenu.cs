using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarMenu : MonoBehaviour
{
    public void Regresar()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    
}
