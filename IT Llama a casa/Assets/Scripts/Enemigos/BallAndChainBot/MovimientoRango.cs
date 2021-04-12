using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRango : MonoBehaviour
{
    public float velocidadX = 1;
    public float contador = 0; //nos permite saber cuantos frames se ha movido el Goomba
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(contador<600){//el goomba se va a mover 499 frames a la izquierda
            rigidbody.velocity =new Vector2(velocidadX, rigidbody.velocity.y);//Mueve el Goomba a la izquierda
            contador++;
        }
        else if(contador == 600){//si ya se movió 500 frames a la izquierda, aumentamos el contador a 1001
            contador = 1201;

        }
        if(contador>601){//como el contador es ahora 1001, nos movemos 500 frames a la derecha
            rigidbody.velocity =new Vector2(-1*velocidadX, rigidbody.velocity.y);//Mueve el Goomba
            contador--;
        }
        else if(contador==601){//contador=501 indica que ya nos movimos 500 frames a la derecha
            contador= 0;//poner el contador a cero permite movernos nuevamente a la izquierda
        }
    }
}
