using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarAnimacion : MonoBehaviour
{
    // Referencia a la nave
    public GameObject nave;
    public GameObject boton;
    
    // Función asignada al botón que resetea la animación en caso de no haber llegado a la meta
    public void Restart()
    {
        nave.transform.position = new Vector3((float) -8.48,(float) 4.49);
        nave.transform.rotation =  Quaternion.Euler(0, 0, 0);
        boton.gameObject.SetActive(false);
        
    }
}
