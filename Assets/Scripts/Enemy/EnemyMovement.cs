using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;


abstract public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _moveDelay; 
    protected List<Action> MoveMethods;
    protected List<Action> TargetMethods;
    protected Vector3  _targetPosition;
    protected float _moveTime;
    private int _randomIndex; 
    private bool CanMove = false;
    private float _currentDelay;

    
    public IEnumerator SetMove(float delay)
    {
        yield return new WaitForSeconds(delay);
        CanMove = true;
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if(CanMove && _currentDelay >= _moveDelay)
        {
            _randomIndex = UnityEngine.Random.Range(0,MoveMethods.Count);
            MoveMethods[_randomIndex]();
            _currentDelay = - _moveTime;
        }
    }


}
