using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permite cerrar una ventana emergente
 * Autor: Erick Bustos
 */

public class CierraVentana : MonoBehaviour
{
    //Referencia a la ventana
    public GameObject ventana;
    
    public void Cerrar()
    {
        ventana.gameObject.SetActive(false);
    }
}
