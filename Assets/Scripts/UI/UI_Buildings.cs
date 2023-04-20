using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Buildings : MonoBehaviour
{
    // this is actually just for the ants lol
    [SerializeField] private int _prefabIndex = 0;
    [SerializeField] Button _button = null;
    [SerializeField] Vector3 _position = Vector3.zero;
    public static List<Building> buildings = new List<Building> {};
    public EnemyController spawner;


    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        // UI_Shop.instance.SetStatus(false);
        // UI_Main.instance.SetStatus(true);

        Vector3 position = Vector3.zero;
        //buildings.Add(Instantiate(UI_Main.instance._buildingPrefabs[_prefabIndex], position, Quaternion.identity));
        //Building.instance = buildings[buildings.Count - 1];
        //CameraControl.instance.isPlacingBuilding = true;

        EnemyController.spawner = true;
        Player.cashGen += 10;
        //spawner.ChangeSpawningSpeed(100f/Player.cashGen);

    }
}
