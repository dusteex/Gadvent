using System;
using UnityEngine;

public class EnemyLifeHandler : MonoBehaviour
{
    [SerializeField] private float _health;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private Vector3 _spawnPosition;
    bool _spawnPointInitialized = false;
    public void SetSpawnPosition(Vector3 spawnPosition)
    {
        if(_spawnPointInitialized == false)
        {
            _spawnPosition = spawnPosition;
            _spawnPointInitialized = true;
        }
    }

    public void TakeDamage(float reduceValue)
    {
        _health -= reduceValue;
        if(_health <= 0) Death();
    }

    public Action<Vector3> NotifyDeathEnemy;
    private void Death()
    {
        NotifyDeathEnemy.Invoke(_spawnPosition);
        Destroy(gameObject);
    }

}
