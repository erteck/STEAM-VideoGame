using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MejoresPuntuaciones : MonoBehaviour
{
    public Text puntuaciones;
    void Awake()
    {
        StartCoroutine(ObtenerPuntuaciones());

    }

    private IEnumerator ObtenerPuntuaciones(){
        //Encapsular los datos que suben a la red
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/partida/mejoresPuntuaciones");
        yield return request.SendWebRequest(); //Regresa, ejecuta y espera....
        if (request.downloadHandler.text != "error"){// 200
            String registros = request.downloadHandler.text;
            for (int x = 0; x < registros.Length; x++)
            {
                print(registros[x]);
            }
            puntuaciones.text = request.downloadHandler.text;
                    //resultado[0].forEach(element => {
            //console.log(element.JugadorUsername,element.puntuacionAcumulada);
        }
        else{
            print(request.downloadHandler.text);
            puntuaciones.text = "Ocurrió un error :( Vuelve a intentarlo";
        }
    }

}
