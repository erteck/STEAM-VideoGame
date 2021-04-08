using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Mantiene información del estado del personaje (salud y piezas recolectadas)
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/

public class EstadoPJ : MonoBehaviour
{
    //VARIABLES
    public int vidas = 3;                    //vidas del personaje
    public int piezas = 0;                  //Piezas recolectadas por el personaje
    public static EstadoPJ instance; //Referencia a la clase EstadoPJ

    //MÉTODOS
    private void Awake()
    {
        instance = this;    //Asignar la instancia al objeto ejecutado por el código
    }
}
