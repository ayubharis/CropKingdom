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
    [SerializeField] private GameObject _elements = null;

    [SerializeField] public BuildGrid _grid = null;
    [SerializeField] public Building[] _buildingPrefabs = null;
    
    public static UI_Main _instance = null; public static UI_Main instance { get { return _instance; } }
    private bool _active = true; public bool isActive {get {return _active;}}

    private void Awake(){
        _instance = this;
        _elements.SetActive(true);
    }

    private void Start(){
        _shopButton.onClick.AddListener(ShopButtonClicked);
    }

    private void ShopButtonClicked(){
        _active = false;
        UI_Shop.instance._elements.SetActive(true);
        _elements.SetActive(false);
    }
}
