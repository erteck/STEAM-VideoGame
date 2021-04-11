using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Permite mover al personaje
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/
public class MovimientoPJ : MonoBehaviour
{
    //VARIABLES
    public float maxVelocidadX = 10;   //Velocidad para el movimiento en x
    public float maxVelocidadY = 10;   //Velocidad para el movimiento en y
    private float maxVelocidadYNegativa;
    private Rigidbody2D rb2d;         //Referencia al Rigidbody del personaje, usa sus físicas

    //MÉTODOS
    void Start()
    {
        //Método que se manda a llamar antes del primer frame, inicaliza variables
        rb2d = GetComponent<Rigidbody2D>();  //Se enlaza el Rigidbody del personaje con el script
    }

    void Update()
    {
        //Método que se manda a llamar cada frame, en este caso registrará el movimiento del personaje principal
        //Movimiento horizontal:
        float movHorizontal = Input.GetAxis("Horizontal");    //Guarda los inputs del movimiento horizontal en una variable
        rb2d.velocity = new Vector2(movHorizontal * maxVelocidadX, rb2d.velocity.y);    //Se cambia la velocidad del personaje
        maxVelocidadYNegativa = Mathf.Clamp(rb2d.velocity.y,-10.1f,10.1f);
        //Movimiento vertical:
        float movVertical = Input.GetAxis("Vertical");
        if(movVertical > 0 && PruebaPiso.estaEnPiso)  //Se evita el doble salto con la segunda condición
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxVelocidadY);
        }
        //Si la velocidad es negativa (caer) no puede superar el límite de -10.1
        if(rb2d.velocity.y<0){
            rb2d.velocity = new Vector2(rb2d.velocity.x,maxVelocidadYNegativa);
        }
    }
}
