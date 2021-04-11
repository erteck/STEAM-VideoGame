using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Detecta la colisión del jugador con la lava del parkour. 
Regresa al jugador al inicio del parkour
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/
public class ParkourCaida : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Función que se ejecuta si la pieza colisiona con otro Collider
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector2(34.21498f,-18.82151f);
            EstadoPJ.instance.vidas--;
            HUD.instance.ActualizarVidas();
            print(EstadoPJ.instance.vidas.ToString());
        }
    }
}
