using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

/*
 * Permite al usuario agregar bloques de código haciendo uso de los botones
 * en la parte inferior.
 *
 * Autor: Erick Bustos
 */
public class InsertaBloques : MonoBehaviour
{
    // Bloque que se va a instanciar
    public GameObject bloque;
    // Padre al que se va asignar el nuevo objeto
    public GameObject parent;
    // Número asignado a la línea de código
    public static int numBloque = 0;
    // Referencia al botón necesaria para extraer texto de los campos inputfield
    public GameObject boton;
    
    public void AgregarBloque()
    {
        //Crea una nueva instancia de un cierto bloque de programación
        GameObject bloqueClon = Instantiate(bloque, parent.transform);
        numBloque += 1;
        // Asigno el número correspondiente a la línea de código
        bloqueClon.GetComponentInChildren<Text>().text = numBloque.ToString();
        
        // En caso de que se tengan estas etiquetas debemos preservar la información en el inputfield correspondiente
        if (boton.CompareTag("Avanzar") | boton.CompareTag("Frenar"))
        {
            //  Copiar Número
            bloqueClon.GetComponentsInChildren<Text>()[2].text = boton.GetComponentsInChildren<Text>()[2].text;
            // Eliminar número ingresado en botón
            boton.GetComponentInChildren<InputField>().text = "";
        }
    }
}
