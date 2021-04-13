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
    // Lista que se va a construir con la información a ejecutar
    private List<int> instruccion;
    
    // Texto ingresado en botón
    private Text textoBoton;
    
    public void AgregarBloque()
    {
        instruccion = new List<int>();
        //Crea una nueva instancia de un cierto bloque de programación
        GameObject bloqueClon = Instantiate(bloque, parent.transform);
        numBloque += 1;
        // Asigno el número correspondiente a la línea de código
        bloqueClon.GetComponentInChildren<Text>().text = numBloque.ToString();
        
        // En caso de que se tengan estas etiquetas debemos preservar la información en el inputfield correspondiente
        if (boton.CompareTag("Avanzar") | boton.CompareTag("Frenar"))
        {
            // Extraer texto botón
            textoBoton = boton.GetComponentsInChildren<Text>()[2];
            
            //  Copiar Número
            //bloqueClon.GetComponentsInChildren<Text>()[2].text = boton.GetComponentsInChildren<Text>()[2].text;
            bloqueClon.GetComponentsInChildren<Text>()[2].text = textoBoton.text;
            
            if (boton.CompareTag("Avanzar"))
            {
                instruccion.Add(1);
            } 
            else if (boton.CompareTag("Frenar"))
            {
                instruccion.Add(2);
            }
            
            instruccion.Add(int.Parse(textoBoton.text));
            
            // Eliminar número ingresado en botón
            boton.GetComponentInChildren<InputField>().text = "";
        }
        else if (boton.CompareTag("Izquierda"))
        {
            instruccion.Add(3);
        }
        else if (boton.CompareTag("Derecha"))
        {
            instruccion.Add(4);
        }
        
        EjecutarCodigo.instrucciones.Add(instruccion);
    }
}
