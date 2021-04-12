using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Permite que el rango de deteccion se mueva junto con el bot
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/
public class BallAndChainBotMovimiento : MonoBehaviour
{
    public float velocidadX = 1;
    public float contador = 0; //nos permite saber cuantos frames se ha movido el Goomba
    public int framesDerecha;
    public int framesIzquierda;
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprRenderer = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(contador<framesIzquierda){//el goomba se va a mover 499 frames a la izquierda
            rigidbody.velocity =new Vector2(velocidadX, rigidbody.velocity.y);//Mueve el Goomba a la izquierda
            contador++;
            sprRenderer.flipX = true;
        }
        else if(contador == framesIzquierda){//si ya se movió 500 frames a la izquierda, aumentamos el contador a 1001
            contador = framesDerecha;

        }
        if(contador>framesIzquierda+1){//como el contador es ahora 1001, nos movemos 500 frames a la derecha
            rigidbody.velocity =new Vector2(-1*velocidadX, rigidbody.velocity.y);//Mueve el Goomba
            contador--;
            sprRenderer.flipX = false;
        }
        else if(contador==framesIzquierda+1){//contador=501 indica que ya nos movimos 500 frames a la derecha
            contador= 0;//poner el contador a cero permite movernos nuevamente a la izquierda
        }
    }
}
