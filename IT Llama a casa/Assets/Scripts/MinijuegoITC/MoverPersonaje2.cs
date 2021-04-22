using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverPersonaje2 : MonoBehaviour
{
    // Referencia al transform de la nave
    private Transform transform;
    private Rigidbody2D rigidbody2D;

    //VARIABLES NUEVAS
    public static int contadordelvector = 0;
    public static int instruccionactual;
    public static bool comenzaracontar = true;
    public static bool ejecuta = false;

    // Referencia al botón Play
    public Button botonplay;
    
    // Referencia al botón de eliminar línea de código
    public Button botoneliminar;
    
    // Referencia al botón de reiniciar proceso
    public GameObject reiniciar;
    
    // Arreglo con las intrucciones
    public static List<List<int>> instrucciones = new List<List<int>>(); //CAMBIAR EN INSERTA BLOQUES
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void EjecutaCodigo()
    {
        if (InsertaBloques.numBloque > 0)
        {

            // Desactivamos la interactividad de los botones
            botoneliminar.interactable = false;
            botonplay.interactable = false;
            contadordelvector = 0;
            comenzaracontar = true;
     
            
            // Iniciamos la ejecución
            ejecuta = true;
            
        }
    }
    
    void Update()
    {
        //Debug.Log(contadordelvector.ToString());
        //Debug.Log(ejecuta.ToString());
        if (contadordelvector == instrucciones.Count & contadordelvector != 0)
        {
            ejecuta = false;
            Debug.Log("AQUI EJECUTA = FALSE");
            
            if ((rigidbody2D.velocity.x == 0 | rigidbody2D.velocity.x == 0) & (!(transform.position.x <= -8.5) | !(transform.position.y >= 4.5)))
            {
                // Mover contador del vector de instrucciones a 0
                contadordelvector = 0;
                reiniciar.SetActive(true);
                Debug.Log("Activa Reiniciar");
                
            }
            
        }
        
        if (ejecuta)
        {
            instruccionactual = instrucciones[contadordelvector][0];
            
            // Avanzar
            if (instruccionactual == 1)
            {
                transform.Translate(Vector3.right * Time.deltaTime);
                if (comenzaracontar)
                {
                    StartCoroutine(Espera(instrucciones[contadordelvector][1]));
                    comenzaracontar = false;
                }
                
            }
            // Esperar
            else if (instruccionactual == 2)
            {
                if (comenzaracontar)
                {
                    StartCoroutine(Espera(instrucciones[contadordelvector][1]));
                    comenzaracontar = false;
                }
                
            }
            // Girar Izquierda
            else if (instruccionactual == 3)
            {
                transform.Rotate(0,0,Time.deltaTime * 45);
                if (comenzaracontar)
                {
                    StartCoroutine(EsperaRotacion());
                    comenzaracontar = false;
                }
                
            }
            // Girar Derecha
            else if (instruccionactual == 4)
            {
                transform.Rotate(0,0,Time.deltaTime * -45);
                if (comenzaracontar)
                {
                    StartCoroutine(EsperaRotacion());
                    comenzaracontar = false;
                }
                
            }
        }

        
        
    }

    // Rutina que cuenta el tiempo que deben ejecutarse las instrucciones avanzar y parar
    // y al terminar, frena su ejecución y permite ejecutar una nueva intrucción
    public IEnumerator Espera(int tiempo)
    {
        Debug.Log("AQUI EJECUTAMOS ESPERA");
        Debug.Log("Y EJECUTA ES" + ejecuta.ToString());
        yield return new WaitForSeconds(tiempo);
        if (ejecuta)
        {
            contadordelvector += 1;
        }
        comenzaracontar = true;
        
    }
    
    // Rutina que cuenta el tiempo que deben ejecutarse las instrucciones relacionadas con girar
    // y al terminar, frena su ejecución y permite ejecutar una nueva intrucción
    public IEnumerator EsperaRotacion()
    {
        Debug.Log("AQUI EJECUTAMOS ESPERA ROTACION");
              Debug.Log("Y EJECUTA ES " + ejecuta.ToString());
              
        yield return new WaitForSeconds(2);
        Debug.Log("Y la ROTACION ES" + transform.rotation.z);
        if (ejecuta)
        {
            contadordelvector += 1;
        }
        comenzaracontar = true;
    }
}
