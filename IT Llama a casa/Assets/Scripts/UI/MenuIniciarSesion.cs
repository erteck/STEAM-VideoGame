using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking; //Para red. UnityWebRequest
using Newtonsoft.Json; //jSON CONVERT
public class MenuIniciarSesion : MonoBehaviour
{
    //Campos con la información nombre y contraseña
    public Text textoUsername;
    public Text textoPassword;
    public InputField inputPassword;
    public Text textoError;

    //Encapsular datos JSON
    public struct datosJugador{
        public string username;
        public string password;
    }
    private datosJugador datos;
    public void Regresar()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    private IEnumerator enviarDatosInicioSesion(){
        datos.username = textoUsername.text;
        datos.password = inputPassword.text;
        //Encapsular los datos que suben a la red
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/iniciarSesion",forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
        if (request.downloadHandler.text != "failed"){// 200
            var datos = request.downloadHandler.text;
            Dictionary<string, string> datosJugador = 
                JsonConvert.DeserializeObject<Dictionary<string, string>>(datos);
            DatosUsuario.username = datosJugador["username"];
            DatosUsuario.correo = datosJugador["correo"];
            DatosUsuario.idPartida = Int32.Parse(datosJugador["idPartida"]);
            textoError.text = "Bienvenid@ " + textoUsername.text;
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MenuPrincipal");
            textoUsername.text = "";
            textoPassword.text = "";
        }
        else{
            textoError.text = "Usuario o contraseña incorrectos";
            yield return new WaitForSeconds(5);
            textoError.text = "";
            textoUsername.text = "";
            textoPassword.text = "";
        }
    }

    public void IniciarSesion()
    {
        //Aquí va el código que verifique los datos
        StartCoroutine(enviarDatosInicioSesion());
    }
}
