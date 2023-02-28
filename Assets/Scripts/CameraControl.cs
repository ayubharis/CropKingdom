using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraControl : MonoBehaviour
{

    public static CameraControl _instance = null; public static CameraControl instance { get { return _instance; } }

    [SerializeField] private Camera _camera = null;
    [SerializeField] private float _moveSpeed = 50;
    [SerializeField] private float _moveSmooth = 5;
    [SerializeField] private float _zoomSpeed = 25f;
    [SerializeField] private float _zoomSmooth = 10;

    private bool _zooming = false;
    private bool _moving = false;
    private Controls _inputs = null;
    private Vector3 _center = Vector3.zero;

    private float _right = 10;
    private float _left = 10;
    private float _up = 10;
    private float _down = 10;
    private float _angle = 45;
    private float _zoom = 5;
    private float _zoomMax = 10;
    private float _zoomMin = 3;
    private float MAX_POS = 40;

    private Transform _root = null;
    private Transform _pivot = null;
    private Transform _target = null;

    private bool _building = false; public bool isPlacingBuilding {get {return _building;} set {_building = value;}}
    private Vector3 _buildBasePosition = Vector3.zero;
    private void Awake(){
        _instance = this;
        _inputs = new Controls();
        _root = new GameObject("CameraHelper").transform;
        _target = new GameObject("CameraTarget").transform;
        _pivot = new GameObject("CameraPivot").transform;
        _camera.orthographic = true;
        _camera.nearClipPlane = 0;
    }

    private void Start(){
        Initialize(Vector3.zero, 10, 10, 10, 10, 45, 5, 10, 3);
    }

    private void Initialize(Vector3 center, float right, float left, float up, float down, float angle, float zoom, float zoomMax, float zoomMin){
        _center = center;
        _right = right;
        _left = left;
        _up = up;
        _down = down;
        _angle = angle;
        _zoom = zoom;
        _zoomMax = zoomMax;
        _zoomMin = zoomMin;
        _moving = false;
        _zooming = false;

        _camera.orthographicSize = _zoom;

        _pivot.SetParent(_root);
        _target.SetParent(_pivot);

        _pivot.localPosition = Vector3.zero;
        _pivot.localEulerAngles = new Vector3(_angle, 0, 0);
        
        _target.localPosition = new Vector3(0, 0, -10); // -10 can be changed
        _target.localEulerAngles = Vector3.zero;
    }

    private void OnEnable(){
        _inputs.Enable();
        _inputs.Main.Move.started += _ => MoveStarted();
        _inputs.Main.Move.canceled += _ => MoveCancelled();
        _inputs.Main.TouchZoom.started += _ => ZoomStarted();
        _inputs.Main.TouchZoom.canceled += _ => ZoomCancelled();
    }

    private void OnDisable(){
        _inputs.Main.Move.started -= _ => MoveStarted();
        _inputs.Main.Move.canceled -= _ => MoveCancelled();
        _inputs.Main.TouchZoom.started -= _ => ZoomStarted();
        _inputs.Main.TouchZoom.canceled -= _ => ZoomCancelled();
        _inputs.Disable();
    }

    private void MoveStarted(){
        if(_building){
            //_buildBasePosition = CameraScreenPositionToPlanePosition(_inputs.Main.PointerPosition.ReadValue<Vector2>());
        }else{
            _moving = true;
        }
        
    }

    private void MoveCancelled(){
        if(UI_Main.instance.isActive){
            _moving = false;
        }
        
    }

    private void ZoomStarted(){
        if(UI_Main.instance.isActive){
            _zooming = true;
        }
    }

    private void ZoomCancelled(){
        _zooming = false;
    }


    private void AdjustBounds(){
        if (_zoom < _zoomMin){
            _zoom = _zoomMin;
        }
        if (_zoom > _zoomMax){
            _zoom = _zoomMax;
        }
        if(Math.Abs(_root.position.x) > MAX_POS){
            _root.position = new Vector3(Math.Abs(_root.position.x) / _root.position.x * MAX_POS, _root.position.y, _root.position.z);
        }
        if(Math.Abs(_root.position.z) > MAX_POS){
            _root.position = new Vector3(_root.position.x, _root.position.y, Math.Abs(_root.position.z) / _root.position.z * MAX_POS);
        }
    }

    private void Update(){

        if(!Input.touchSupported){
            float mouseScroll = _inputs.Main.MouseScroll.ReadValue<float>();
            if(mouseScroll > 0){
                _zoom -= _zoomSpeed * Time.deltaTime;
            }else if (mouseScroll < 0){
                _zoom += _zoomSpeed * Time.deltaTime;
            }
        }
        else if(_zooming){
            // zoomy
        }
        if(_moving){
            Vector2 move = _inputs.Main.MoveDelta.ReadValue<Vector2>();
            if (move != Vector2.zero){
                move.x /= Screen.width;
                move.y /= Screen.height;
                _root.position -= _root.right.normalized * move.x * _moveSpeed;
                _root.position -= _root.forward.normalized * move.y * _moveSpeed;
            }
        }
        AdjustBounds();
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _zoom, _zoomSmooth * Time.deltaTime);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _target.position, _moveSmooth * Time.deltaTime);
        _camera.transform.rotation = _target.rotation;
    }

    private Vector3 CameraScreenPositionToWorldPosition(Vector2 position){
        float h = _camera.orthographicSize * 2f;
        float w = _camera.aspect * h;

        Vector3 anchor = _camera.transform.position - (_camera.transform.right.normalized * w/2f) - (_camera.transform.up.normalized * h/2f);
        return anchor + (_camera.transform.right.normalized * position.x / Screen.width * w) + (_camera.transform.up.normalized * position.y / Screen.height * h);
    }
}
