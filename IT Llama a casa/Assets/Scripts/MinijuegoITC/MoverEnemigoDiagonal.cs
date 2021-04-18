using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    *Permite movilizar diaognalmente al enemigo 
    *Sin necesidad de ser controlado
    *Autor: David Rodriguez, Erick Bustos
*/

public class MoverEnemigoDiagonal : MonoBehaviour
{
    //VARIABLES
    public float maxVelocidadY = -5;  //Movimiento Vertical
    public float maxVelocidadX = -5;  //Movimiento Horizontal

    public float xInicial;

    public float xFinal;
    


    
    private Rigidbody2D rigidbody;  //Para fisica

    //METODOS
    
    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        rigidbody = GetComponent<Rigidbody2D>();  //Enlazar RB --> script
    }

    // Update is called once per frame (frecuentemente 60 veces/seg)
    void Update()
    {
        if (transform.position.x <= xFinal)
        {
            //Desplaza al personaje en el eje -y
            maxVelocidadY = 5;
            maxVelocidadX = 5;

            
        }else if(transform.position.x >= xInicial)
        {
            //Desplaza al personaje en el eje y
            maxVelocidadY = -5;
            maxVelocidadX = -5;

        }
        
        rigidbody.velocity = new Vector2(maxVelocidadX, maxVelocidadY);

    }
}