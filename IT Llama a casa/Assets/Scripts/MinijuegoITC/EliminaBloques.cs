using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Elimina el último bloque de código agregado
 * Autor: Erick Bustos
 */
public class EliminaBloques : MonoBehaviour
{
    public GameObject contenedorBloques;
    public void eliminar()
    {
        if (InsertaBloques.numBloque > 0)
        {
            Destroy(contenedorBloques.transform.GetChild(contenedorBloques.transform.childCount - 1).gameObject);
            InsertaBloques.numBloque -= 1;
        }
        
    }
}
