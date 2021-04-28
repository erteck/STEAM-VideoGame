using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking; //Para red. UnityWebRequest
using Newtonsoft.Json; //jSON CONVERT
/*
Permite darle funcionalidades a los componentes del menú
Autores: David Rodríguez Fragoso, Edna Jacqueline Zavala Ortega, 
Erick Alberto Bustos Cruz, Erick Hernández Silva, Israel Sánchez Miranda
*/

public class MenuPrincipal : MonoBehaviour
{
    //VARIABLES
    public Image imagenFondo; //Imagen para hacer el efecto de fade-out

    //MÉTODOS
    private IEnumerator crearNuevaPartida(){
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/partida/agregarPartida?username=" + DatosUsuario.username + "&correo="+DatosUsuario.correo);
        yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
        if (request.downloadHandler.text != "failed"){// 200
            var datos = request.downloadHandler.text;
            Dictionary<string, string> datosJugador = 
                JsonConvert.DeserializeObject<Dictionary<string, string>>(datos);
            DatosUsuario.username = datosJugador["username"];
            DatosUsuario.correo = datosJugador["correo"];
            DatosUsuario.idPartida = Int32.Parse(datosJugador["idPartida"]);
            SceneManager.LoadScene("Mapa");
        }
        else{
            yield return new WaitForSeconds(5);
        }
    }
    //MÉTODOS
    public void Jugar()
    {
        //Si no hay una partida en curso, entonces inicia una nueva
        if(DatosUsuario.idPartida == 0){
            StartCoroutine(crearNuevaPartida());
        }else{//si ya hay una partida en curso, la continúa
             //Función que le otorgará la posibilidad de iniciar el juego al componente que se le asigne
            SceneManager.LoadScene("Mapa");
        }
    }

    public void Salir()
    {
        //Función que le otorgará la posibilidad de salirse de la aplicación (juego) al componente que se le asigne
        Application.Quit();
    }

    public void Regresar()
    {
        SceneManager.LoadScene("MenuIniciarSesion");
    }

    public void EditarPerfil()
    {
        SceneManager.LoadScene("EditarPerfil");
    }
    
    public void MejoresPuntuaciones()
    {
        SceneManager.LoadScene("MejoresPuntuaciones");
    }
    

    public void Creditos()
    {
        //Función que se asocia al botón de créditos, permite hacer el efecto de fade out y cambiar de escena
        //Se crea el efecto de Fade out, dura dos segundos
        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(0, 0.5f, true);
        
        //Se empieza una corrutina para cambiar de escena
        StartCoroutine(CambiarEscena("Creditos"));
    }

    public IEnumerator CambiarEscena(string escena)
    {
        //Función que crea todos los cambios de escena mediante una corrutina para crear el efecto de fade out
        yield return new WaitForSeconds(0.5f);

        //Después de esperar por 2 segundos carga la escena correspondiente
        SceneManager.LoadScene(escena);
    }
}
