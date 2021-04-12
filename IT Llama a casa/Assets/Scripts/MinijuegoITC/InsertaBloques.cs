using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permite al usuario agregar bloques de código haciendo uso de los botones
 * en la parte inferior.
 *
 * Autor: Erick Bustos
 */
public class InsertaBloques : MonoBehaviour
{
    public GameObject bloque;
    public GameObject parent;
    public static int numBloque;
    
    public void AgregarBloque()
    {
        //Crea una nueva instancia de un cierto bloque de programación
        GameObject bloqueClon = Instantiate(bloque, parent.transform);
        
    }
}
