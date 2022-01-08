using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;


public class Enemy00_Movement : EnemyMovement
{

    private void Start()
    {
        MoveMethods = new List<MoveMethod>(){StrafeMovement,StrafeMovement,StrafeMovement,CycleMovement};
        TargetMethods = new List<TargetMethod>(){GetStraightTarget};
    }
    
    private void CycleMovement(Vector3 secondPos)
    {
        Sequence  s = DOTween.Sequence();
        Vector3 startPos = transform.position;
        _moveTime = 3f;
        Move(secondPos,0.5f,s);
        Move(startPos,0.5f,s);
        Move(secondPos,0.5f,s);
        Move(startPos,0.5f,s);
        Move(secondPos,0.5f,s);
        Move(startPos,0.5f,s);
    }

    private void StrafeMovement(Vector3 secondPos)
    {
        Sequence  s = DOTween.Sequence();
        Vector3 startPos = transform.position;
        _moveTime = 0.5f;
        Move(secondPos,0.5f,s);
    }

    private Vector3 GetStraightTarget()
    {
        int directionX =  UnityEngine.Random.Range(-1,2);
        int directionY =  UnityEngine.Random.Range(-1,2);
        float moveValueX = UnityEngine.Random.Range(directionX*0.6f,directionX*0.4f);
        float moveValueY = UnityEngine.Random.Range(directionY*0.6f,directionY*0.4f);
        return transform.position + new Vector3(moveValueX,moveValueY,0);

    }


    private void Move(Vector3 pos,float time, Sequence s,Ease ease = Ease.Linear)
    {
        pos = Clamp(pos);
        s.Append(transform.DOMove(pos,time,false).SetEase(ease));
    }
    private void Wait(float time,Sequence s,Ease ease = Ease.Linear)
    {
        s.Append(transform.DOMove(transform.position,time).SetEase(ease));
    }

    private Vector3 Clamp(Vector3 pos)
    {
        Vector3 target = pos;
        if(pos.y > _leftTopLimiterPos.y)
            target.y = _leftTopLimiterPos.y;

        else if(pos.y < _rightBottomLimiterPos.y)
            target.y = _rightBottomLimiterPos.y;

        if (pos.x < _leftTopLimiterPos.x)
            target.x = _leftTopLimiterPos.x;

        else if (pos.x > _rightBottomLimiterPos.x)
            target.x = _rightBottomLimiterPos.x;

        return target;
    }



}
