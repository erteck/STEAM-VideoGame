using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Permite determinar si el jugador choca con un enemigo o pasa al siguiente nivel.
 * Al chocar la nave con un enemigo ejecuta la animación de una explosión y regresa al jugador a la posición inicial.
 * Al colisionar con el planeta de destino, se desactivan los enemigos del nivel actual, se despliegan los
 * enemigos del nuevo nivel y se regresa al jugador a la posición inicial.
 */
public class Nave2 : MonoBehaviour
{
    
    // Nivel Actual
    public static int nivelActual = 1;
    
    // Enemigos de cada nivel
    public GameObject enemigosNivel1;
    public GameObject enemigosNivel2;
    public GameObject enemigosNivel3;
    public GameObject enemigosNivel4;
    public GameObject enemigosNivel5;
    
    // Referencia al botón Play
    public Button botonplay;
    
    // Referencia al botón de eliminar línea de código
    public Button botoneliminar;
    
    // Referencia al botón reiniciar
    public GameObject reiniciar;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cuando el jugador completa el nivel
        if (other.gameObject.CompareTag("Destino"))
        {
            Debug.Log("DESTINO");
            // Actualizar nivel
            nivelActual += 1;

            // Cambiar de enemigos
            if (nivelActual == 2)
            {
                enemigosNivel1.SetActive(false);
                enemigosNivel2.SetActive(true);
                
            }
            else if (nivelActual == 3)
            {
                enemigosNivel2.SetActive(false);
                enemigosNivel3.SetActive(true);
            }
            else if (nivelActual == 4)
            {
                enemigosNivel3.SetActive(false);
                enemigosNivel4.SetActive(true);
            }
            else if (nivelActual == 5)
            {
                enemigosNivel4.SetActive(false);
                enemigosNivel5.SetActive(true);
            }
            else if (nivelActual == 6)
            {
                SceneManager.LoadScene("Mapa");
            }
       
            // Desactivar la ejecución de animaciones
            MoverPersonaje2.ejecuta = false;

            // Mover contador del vector de instrucciones a 0
            MoverPersonaje2.contadordelvector = 0;
            
            // Regresar la nave a su posición inicial
            transform.position = new Vector3((float) -8.5,(float) 4.5);
            transform.rotation =  Quaternion.Euler(0, 0, 0);
            
            // Reactivar Botones
            botoneliminar.interactable = true;
            botonplay.interactable = true;
            reiniciar.SetActive(false);
            
        }
        else
        {
            Debug.Log("EXPLOSION");
            // Desactivar la ejecución de animaciones
            MoverPersonaje2.ejecuta = false;

            // Mover contador del vector de instrucciones a 0
            MoverPersonaje2.contadordelvector = 0;
            
            //Dejar de dibujar la nave
            GetComponent<SpriteRenderer>().enabled = false;
            
            //Activar la explosión
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            // Llamar corrutina
            StartCoroutine(ContarExplosion());
            

        }
    }

    private IEnumerator ContarExplosion()
    {
        
        // Espera medio segundo y desactiva la explosión
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
        // Espera medio segundo y regresa la nave al punto inicial
        transform.position = new Vector3((float) -8.5,(float) 4.5);
        //transform.rotation =  Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.identity;
        //Dibujar la nave de nuevo
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(4.5f);
        
        // Reactivar Botones
        botoneliminar.interactable = true;
        botonplay.interactable = true;
        
    }
}
