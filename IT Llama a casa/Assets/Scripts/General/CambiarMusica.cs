using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarMusica : MonoBehaviour
{
    public AudioClip audioNuevo;

    public AudioSource audioFondo;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           audioFondo.clip=audioNuevo;
           audioFondo.Play();
        }
    }
}
