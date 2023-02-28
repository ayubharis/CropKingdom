using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public static Building _instance = null; public static Building instance { get { return _instance; } set {_instance = value;}}
    
    [System.Serializable] public class Level {
        public int level = 1;
        public Sprite icon = null;
        public GameObject mesh = null;
    }
    private BuildGrid _grid = null;

    [SerializeField] private int _rows = 1;
    [SerializeField] private int _columns = 1;

    [SerializeField] private MeshRenderer _baseArea = null;

    [SerializeField] private Level[] _levels = null;

    private int _currentX = 0;
    private int _currentY = 0;
    private int _X = 0;
    private int _Y = 0;

    public void PlacedOnGrid(int x, int y){
        _currentX = x;
        _currentY = y;
        _X = x;
        _Y = y;

    }

    public void RemovedFromGrid(){
        _instance = null; 
        CameraControl.instance.isPlacingBuilding = false;
        Destroy(gameObject);

    }

    public void UpdatePositionOnGrid(){

    }
}
