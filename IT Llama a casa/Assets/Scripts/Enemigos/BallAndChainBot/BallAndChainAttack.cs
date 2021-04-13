using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Permite que el enemigo detecte al jugador en rango y cambia la animación de ataque
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/
public class BallAndChainAttack : MonoBehaviour
{
    private Rigidbody2D rb2d;             //Rigidbody del personaje, físicas
    private Animator anim;                //Animator del personaje, animaciones
    private SpriteRenderer sprRenderer;   //Sprite Renderer del personaje, orientación
    public float tiempoInvulnerable;
    public SpriteRenderer sprJugador;
    //Vuelve al jugador invulnerable durante n segundos luego de ser atacado
    private IEnumerator Invulnerabilidad(){
        EstadoPJ.instance.invulerable = true;
        yield return new WaitForSeconds (tiempoInvulnerable);
        EstadoPJ.instance.invulerable = false;
    }
    //Simula un "blink" al ser atacado el jugador
    private IEnumerator animAtacado(){
        sprJugador.sortingOrder = -100;
        yield return new WaitForSeconds (0.32f);
        sprJugador.sortingOrder = 0;
        yield return new WaitForSeconds (0.32f);
        sprJugador.sortingOrder = -100;
        yield return new WaitForSeconds (0.32f);
        sprJugador.sortingOrder = 0;
        
    }
    //MÉTODOS
    void Start()
    {
        //Función que se manda a llamar antes del primer frame, se inicializan las variables
        //Se obtiene cada uno de los componentes enlistados para enlazarlos con el script:
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    //Cambia la animación cuando es necesario
    void Update()
    {
        //Cambia la animación si el jugador está en rango
            anim.SetBool("JugadorEnRango",JugadorEnRango.estaEnRango);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Función que se ejecuta en cuanto el personaje hace contacto con otro Collider, indicando que está en el piso
        if(other.gameObject.tag == "Player")   //Si el Collider no es de una pieza entonces el personaje está en el piso
        {
            if(!EstadoPJ.instance.invulerable){
                EstadoPJ.instance.vidas--;
                HUD.instance.ActualizarVidas();
                StartCoroutine(Invulnerabilidad());
                StartCoroutine(animAtacado());
            }
        }
    }

    
}
