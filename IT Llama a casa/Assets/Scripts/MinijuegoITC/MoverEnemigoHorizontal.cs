using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
public class MoverEnemigoHorizontal : MonoBehaviour
{
    //VARIABLES
    public float maxVelocidadX = 5;  //Movimiento Horizontal
    private Rigidbody2D rigidbody;  //Para fisica
    private SpriteRenderer spriterenderer;

    //public float xInicial;
    //public float xFinal;

    //METODOS
    
    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        rigidbody = GetComponent<Rigidbody2D>();  //Enlazar RB --> script
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame (frecuentemente 60 veces/seg)
    void Update()
    {
        if (transform.position.x <= -6.54)
        {
            //Desplaza al personaje en el eje -y
            maxVelocidadX = 5;
            spriterenderer.flipX=false;

            
        }else if(transform.position.x >= 1.59)
        {
            //Desplaza al personaje en el eje y
            maxVelocidadX = -5;
            spriterenderer.flipX=true;

        }
        
        rigidbody.velocity = new Vector2(maxVelocidadX, 0);

    }
}