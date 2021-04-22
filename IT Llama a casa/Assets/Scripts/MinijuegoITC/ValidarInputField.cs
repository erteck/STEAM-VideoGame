using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Script para prevenir que el usuario deje un inputfield vacío
 * Se rellena automáticamente con cero
 */
public class ValidarInputField : MonoBehaviour
{
    public InputField inputfield;

    public void CheckForEmpty()
    {
        if (inputfield.text.Length == 0)
        {
            inputfield.text = "0";
        }
    }
}
