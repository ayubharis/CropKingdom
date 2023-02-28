using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{

    [SerializeField] public GameObject _elements = null;

    public static UI_Shop _instance = null; public static UI_Shop instance { get { return _instance; } }

    private void Awake(){
        _instance = this;
        _elements.SetActive(false);
    }
}
