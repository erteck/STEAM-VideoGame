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
}
