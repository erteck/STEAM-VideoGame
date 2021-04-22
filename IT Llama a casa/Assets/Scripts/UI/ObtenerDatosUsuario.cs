using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Obtiene la información del correo del jugador y lo 
* despliega en el campo de la escena Editar Perfil
*/
public class ObtenerDatosUsuario : MonoBehaviour
{
    public InputField nuevoCorreo;
    
    public void Start()
    {
        nuevoCorreo.text = DatosUsuario.correo;
        
    }

}
