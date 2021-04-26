using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Permite que un enemigo se mueva en el eje x,y o ambos.
Autor: Erick Hernández Silva
*/
public class movimientoEnemigo : MonoBehaviour
{
    public float velocidadX = 0; //Velocidad en x por defecto
    public float velocidadY = 0; //Velocidad en y por defecto
    //nos permite saber cuantos frames se ha movido el enemigo y 
    //si primero irá a la izq o derecha
    public float contador = 0; 
    public bool negativo = true;
    public int frames;
    private Rigidbody2D rigidbody;
    private SpriteRenderer sprRenderer;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprRenderer = GetComponent<SpriteRenderer>();  
    }

    void Update()
    {   
        if(contador<frames && !negativo){
            rigidbody.velocity =new Vector2(velocidadX, velocidadY);
            contador++;
            if(velocidadX>0){
                sprRenderer.flipX = true;
            }
        }
        else if (contador == frames && negativo){
            contador = 0;
            negativo = !negativo;
        }
        if(contador<frames && negativo){
            rigidbody.velocity =new Vector2(-1*velocidadX, -1*velocidadY);
            contador++;
            if(velocidadX>0){
                sprRenderer.flipX = false;
            }
        }
        else if (contador == frames && !negativo){
            contador = 0;
            negativo = !negativo;
        }
    }
}
