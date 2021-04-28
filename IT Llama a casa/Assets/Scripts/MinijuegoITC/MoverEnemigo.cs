using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    *Permite movilizar en el eje y al personaje 
    *Sin necesidad de ser controlado
    *Autor: David Rodriguez, Erick Bustos
*/

public class MoverEnemigo : MonoBehaviour
{
    //VARIABLES
    public float maxVelocidadY = -5;  //Movimiento Horizontal
    private Rigidbody2D rb2D;  //Para fisica

    //METODOS
    
    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        rb2D = GetComponent<Rigidbody2D>();  //Enlazar RB --> script
    }

    // Update is called once per frame (frecuentemente 60 veces/seg)
    void Update()
    {
        if (transform.position.y <= -4.35)
        {
            //Desplaza al personaje en el eje -y
            maxVelocidadY = 5;

            
        }else if(transform.position.y >= 4.54)
        {
            //Desplaza al personaje en el eje y
            maxVelocidadY = -5;

        }
        
        rb2D.velocity = new Vector2(0, maxVelocidadY);

    }
}