using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EjecutarCodigo : MonoBehaviour
{
    public static List<List<int>> instrucciones = new List<List<int>>();
    

    public void ejecutaCodigo()
    {
        foreach (var bloque in instrucciones)
        {
            if (bloque[0] == 1)
            {
                //Avanza bloque[1] espacios
            }
            else if (bloque[0] == 2)
            {
                //Espera bloque[1] segundos
            }
            else if (bloque[0] == 3)
            {
                // Gira izquierda
            }
            else if (bloque[0] == 4)
            {
                //Gira derecha
            }
        }
    }
    
}
