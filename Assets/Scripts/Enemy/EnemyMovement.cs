using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;


abstract public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _moveDelay; 
    protected List<MoveMethod> MoveMethods;
    protected List<TargetMethod> TargetMethods;
    protected Vector3  _targetPosition;
    protected Vector3 _leftTopLimiterPos;
    protected Vector3 _rightBottomLimiterPos;
    protected float _moveTime;
    private int _randomMoveIndex;
    private int _randomTargetIndex; 


    private bool CanMove = false;
    private float _currentDelay;

    
    public IEnumerator SetMove(float delay , Vector3 leftTopLimiterPos, Vector3 rightBottomLimiterPos)
    {
        yield return new WaitForSeconds(delay);
        this._leftTopLimiterPos = leftTopLimiterPos;
        this._rightBottomLimiterPos = rightBottomLimiterPos;
        CanMove = true;
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if(CanMove && _currentDelay >= _moveDelay)
        {
            _randomMoveIndex = UnityEngine.Random.Range(0,MoveMethods.Count);
            _randomTargetIndex = UnityEngine.Random.Range(0,TargetMethods.Count);

            MoveMethods[_randomMoveIndex](TargetMethods[_randomTargetIndex]());
            _currentDelay = - _moveTime;
        }
    }

    protected delegate Vector3 TargetMethod();
    protected delegate void MoveMethod(Vector3 secondPos);



}
