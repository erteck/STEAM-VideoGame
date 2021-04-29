using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permite que los botónes suenen al ser presionados
 * Autor: Erick Bustos
 */
public class SonidoBotones : MonoBehaviour
{ 
    public AudioSource boton;

    public void SonidoBoton()
    {
        boton.Play();
    }
 
}
