using UnityEngine;
using DG.Tweening;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    private Camera _mainCamera; 
    private Action Move;
    private const float MAX_MOVE_TIME = 1;

    void Start()
    {
        #if UNITY_ANDROID
            Move = MoveMobile;
        #else
            Move = MovePC;
        #endif

        _movementSpeed = _movementSpeed < MAX_MOVE_TIME ? MAX_MOVE_TIME : _movementSpeed;
        _mainCamera = Camera.main;

    }
    private void FixedUpdate()
    {
        Move();
    }

    private void MovePC()
    {
        Vector3 targetPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        transform.DOMove(targetPos,MAX_MOVE_TIME/_movementSpeed);
    }
    private void MoveMobile()
    {
        if(Input.touchCount == 0 ) return;
        Vector3 targetPos = _mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        targetPos.z = transform.position.z;
        transform.DOMove(targetPos,MAX_MOVE_TIME/_movementSpeed);
    }

}
