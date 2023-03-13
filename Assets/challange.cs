using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challange : MonoBehaviour
{
    public static bool clicked = false;
 
    public void ButtonClicked() {
        Debug.Log("CLicked");
        clicked = true;
    }
}
