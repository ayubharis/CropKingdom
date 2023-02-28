using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Buildings : MonoBehaviour
{
    [SerializeField] private int _prefabIndex = 0;
    [SerializeField] Button _button = null;
    [SerializeField] Vector3 _position = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(Clicked);
    }

    // Update is called once per frame
    private void Clicked()
    {
        //UI_Shop.instance.SetStatus(false);
        // UI_Main.instance.SetStatus(true);

        Vector3 position = Vector3.zero;
        Building building = Instantiate(UI_Main.instance._buildingPrefabs[_prefabIndex], position, Quaternion.identity);
        Building.instance = building;
        CameraControl.instance.isPlacingBuilding=true;
    }
}
