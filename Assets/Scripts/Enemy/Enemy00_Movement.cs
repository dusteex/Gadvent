using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;


public class Enemy00_Movement : EnemyMovement
{

    private void Start()
    {
        MoveMethods = new List<Action>(){MoveLeft,MoveRight};
        TargetMethods = new List<Action>(){MoveLeft,MoveRight};
    }
    

    private void MoveLeft()
    {
        _moveTime = 3f;
        Vector3 startPos = transform.position;
        Vector3 secondPos = transform.position + new Vector3(-0.6f,0,0);
        Sequence s = DOTween.Sequence();
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
    
    }
    private void MoveRight()
    {
        _moveTime = 3f;
        Vector3 startPos = transform.position;
        Vector3 secondPos = transform.position + new Vector3(+0.6f,0,0);
        Sequence s = DOTween.Sequence();
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
    
    }

    private void MoveDiagonal()
    {
        _moveTime = 3f;
        Vector3 startPos = transform.position;
        Vector3 secondPos = transform.position + new Vector3(+0.6f,0.6f,0);
        Sequence s = DOTween.Sequence();
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
        MoveX(secondPos,0.5f,s);
        MoveX(startPos,0.5f,s);
    }



    private void MoveX(Vector3 pos,float time, Sequence s,Ease ease = Ease.Linear)
    {
        s.Append(transform.DOMoveX(pos.x,time,false).SetEase(ease));
    }
    private void Wait(float time,Sequence s,Ease ease = Ease.Linear)
    {
        s.Append(transform.DOMove(transform.position,time).SetEase(ease));
    }



}
