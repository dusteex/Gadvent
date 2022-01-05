using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    private Camera _mainCamera; 
    private bool _moveCondition;

    private const float MAX_MOVE_TIME = 1;

    void Start()
    {
        _movementSpeed = _movementSpeed < MAX_MOVE_TIME ? MAX_MOVE_TIME : _movementSpeed;

        _mainCamera = Camera.main;
        _moveCondition = GetMoveCondition();

    }
    void FixedUpdate()
    {
        if(_moveCondition)
        {
            Vector3 targetPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            transform.DOMove(targetPos,MAX_MOVE_TIME/_movementSpeed);
        }
    }
    private bool GetMoveCondition()
    {
        #if UNITY_ANDROID
            return Input.GetMouseButton(0);
        #else
            return true;
        #endif
    }

}
