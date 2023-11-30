using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Cinemachine;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D _screenCollider;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform _checkpointColliderRight;
    [SerializeField] private Transform _checkpointColliderLeft;

    [SerializeField] private float _checkpointSize = 10f;

    private CinemachineConfiner2D _cinemachineCollider;
    
    //NW, SW, SE, NE
    private Vector2[] _originalCollider;
    private int _currentCheckpoint;
    private bool _noWayBack = false;
    
    void Awake()
    {
        _originalCollider = _screenCollider.GetPath(0);
        _cinemachineCollider = _virtualCamera.GetComponent<CinemachineConfiner2D>();
    }

    private void Start()
    {
        List<Vector2> newPoints = new []
        {
                _originalCollider[0],
                _originalCollider[1],
                new Vector2(_originalCollider[1].x + (_currentCheckpoint + 1) * _checkpointSize, _originalCollider[2].y),
                new Vector2(_originalCollider[1].x + (_currentCheckpoint + 1) * _checkpointSize, _originalCollider[3].y),
        }.ToList();

        _screenCollider.SetPath(0, newPoints);
        _cinemachineCollider.InvalidateCache();

        _checkpointColliderRight.position = new Vector2((_currentCheckpoint + 1) * _checkpointSize, 0f);
    }

    private void Update()
    {
        UpdateLeftCollider();
    }
    
    private void UpdateLeftCollider() {
        float cameraWidth = 2 * _virtualCamera.m_Lens.OrthographicSize * Screen.width / Screen.height;
        float leftBorder = _virtualCamera.transform.position.x - cameraWidth/2;

        if (leftBorder < 0 && !_noWayBack)
        {
            _noWayBack = true;
            _checkpointColliderLeft.transform.position = Vector2.zero;
        }
        else if (leftBorder < _checkpointColliderRight.position.x - cameraWidth && leftBorder > _checkpointColliderLeft.transform.position.x)
        {
            _checkpointColliderLeft.transform.position = new Vector2(leftBorder, 0);
            
            List<Vector2> newPoints = new []
            {
                new Vector2(leftBorder, _originalCollider[0].y),
                new Vector2(leftBorder, _originalCollider[1].y),
                new Vector2(_originalCollider[1].x + (_currentCheckpoint + 1) * _checkpointSize, _originalCollider[2].y),
                new Vector2(_originalCollider[1].x + (_currentCheckpoint + 1) * _checkpointSize, _originalCollider[3].y),
            }.ToList();

            _screenCollider.SetPath(0, newPoints);
            _cinemachineCollider.InvalidateCache();
        }
        else if (leftBorder >= _checkpointColliderRight.position.x - cameraWidth)
        {
            _checkpointColliderLeft.transform.position = new Vector2(_checkpointColliderRight.position.x - cameraWidth, 0);    
        }
        
    }
}
