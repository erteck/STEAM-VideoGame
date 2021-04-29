using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permite desplegar las instrucciones de nuevo
 * Autor: Erick Bustos
 */
public class DesplegarInstrucciones : MonoBehaviour
{
    public GameObject panelInstrucciones;

    public void DespliegaInstrucciones()
    {
        panelInstrucciones.SetActive(true);
    }
}
