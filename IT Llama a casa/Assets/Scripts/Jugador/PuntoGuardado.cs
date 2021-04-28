using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; //jSON CONVERT
using UnityEngine.UI;
using UnityEngine.Networking;
public class PuntoGuardado : MonoBehaviour
{
    public static PuntoGuardado instance;
    public float guardadoY;
    public float guardadoX;
    private void Start()
    {
        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Guarda la posición del jugador al pasar por el collider
        if(other.gameObject.tag == "Player"){
            PlayerPrefs.SetFloat("ultimaPosicionX",guardadoX);
            PlayerPrefs.SetFloat("ultimaPosicionY",guardadoY);
            PlayerPrefs.SetInt("vidas",EstadoPJ.instance.vidas);
            if(CargarJugador.piezaIBT){
                PlayerPrefs.SetInt("piezaIBT",1);
            }
            PlayerPrefs.Save();
            guardarPuntoControl();
        }
    }
    public struct Partida{
        public string username;
        public int idPartida;
        public int puntuacionAcumulada;
        public int vidas;
        public int inventario;
        public string estatus;

    }
    private Partida datosPartida;
    //Guarda los datos de la partida en general
    private IEnumerator guardarPartida(string estatus, bool partidaFinalizada){
        print(DatosUsuario.idPartida.ToString());
        print(EstadoPJ.instance.piezas.ToString());
        datosPartida.username = DatosUsuario.username;
        datosPartida.idPartida = DatosUsuario.idPartida;
        datosPartida.puntuacionAcumulada = CargarJugador.puntuacionGlobal;
        datosPartida.vidas = EstadoPJ.instance.vidas;
        datosPartida.inventario = EstadoPJ.instance.piezas;
        datosPartida.estatus = estatus;
        //Encapsular los datos que suben a la red
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosPartida));
        if (!partidaFinalizada)
        {
            UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/partida/guardarPartida",forma);
            yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
            if (request.downloadHandler.text == "success"){// 200
                print("UPDATE exitoso");
            }
            else{
                print(request.downloadHandler.text);
                yield return new WaitForSeconds(3);
                guardarPuntoControl();
            }
        }
        else
        {
            UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/partida/finalizarPartida",forma);
            yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
            if (request.downloadHandler.text == "success"){// 200
                print("UPDATE exitoso");
                datosPartida.idPartida = 0;
            }
            else{
                print(request.downloadHandler.text);
                yield return new WaitForSeconds(3);
                guardarPuntoControl();
            }
        }

    }
    public void guardarPuntoControl()
    {
        StartCoroutine(guardarPartida("En progreso", false));
    }

    public void PartidaCompletada()
    {
        StartCoroutine(guardarPartida("Finalizada", true));
    }

    public void PartidaPerdida()
    {
        StartCoroutine(guardarPartida("Perdido", true));
    }

//Finaliza la partida y actualiza los datos finales
/*
    private IEnumerator FinalizarPartida(){
        print(DatosUsuario.idPartida.ToString());
        print(EstadoPJ.instance.piezas.ToString());
        datosPartida.idPartida = DatosUsuario.idPartida;
        datosPartida.puntuacionAcumulada = CargarJugador.puntuacionGlobal;
        datosPartida.vidas = EstadoPJ.instance.vidas;
        datosPartida.inventario = EstadoPJ.instance.piezas;
        datosPartida.username = DatosUsuario.username;
        datosPartida.estatus = "Perdido";
        //Encapsular los datos que suben a la red
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosPartida));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/partida/FinalizarPartida",forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
        if (request.downloadHandler.text == "success"){// 200
            print("UPDATE exitoso");
            DatosUsuario.idPartida = 0;
        }
        else{
            print(request.downloadHandler.text);
            yield return new WaitForSeconds(3);
            terminarPartida();
        }
    }
    //Método llamado para finalizar la partida
    public void terminarPartida(){
        DatosUsuario.idPartida = 0;
        StartCoroutine(FinalizarPartida());
    }*/

    public struct Jugada{
        public string minijuego;
        public string fechaInicio;
        public string fechaFinal;
        public int puntaje;

    }
    private Jugada datosJugada;
    //Guarda los datos del minijuego jugado
    private IEnumerator guardarMinijuego(string minijuego, int puntaje, string fechaInicio, string fechaFinal){
        datosJugada.minijuego = minijuego;
        datosJugada.fechaInicio = fechaInicio;
        datosJugada.fechaInicio = fechaFinal;
        datosJugada.puntaje = puntaje;
        //Encapsular los datos que suben a la red
        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datosJugada));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/editarPerfil",forma);
        yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
        if (request.downloadHandler.text == "success"){// 200
            yield return new WaitForSeconds(10);

        }
        else{
            print(request.downloadHandler.text);
            yield return new WaitForSeconds(10);
        }
    }
    //Guarda la jugada con los parámetros especificados
    public void subirJugada(string minijuego, int puntaje, string fechaInicio, string fechaFinal){
        StartCoroutine(guardarMinijuego(minijuego, puntaje,fechaInicio,fechaFinal));
    }
}
