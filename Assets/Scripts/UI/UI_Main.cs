using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _cashText = null;
    [SerializeField] public TextMeshProUGUI _otherText = null;
    [SerializeField] private Button _shopButton = null;

    [SerializeField] private Building[] _buildingPrefabs = null;
    
    private static UI_Main _instance = null; public static UI_Main instance { get { return _instance; } }

    private void Awake(){
        _instance = this;
    }

    private void Start(){
        _shopButton.onClick.AddListener(ShopButtonClicked);
    }

    private void ShopButtonClicked(){

    }
}