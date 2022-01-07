using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] protected float _attackDelay;
    [SerializeField] protected float _damage;

    public float AttackDelay => _attackDelay;

    abstract public void Attack();
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
