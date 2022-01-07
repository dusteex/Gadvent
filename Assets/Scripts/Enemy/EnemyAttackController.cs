using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private EnemyAttacking _enemyAttacking;
    private float _currentDelay;
    private float _targetDelay;

    private void Start()
    {
        _enemyAttacking = GetComponent<EnemyAttacking>();
        SetRandomDelay();
    }

    void Update()
    {
        _currentDelay+=Time.deltaTime;
        if(isEnemyCanAttack()) _enemyAttacking.Attack();
    }

    private bool isEnemyCanAttack()
    {
        if(_currentDelay >= _targetDelay )
        {
            SetRandomDelay();
            _currentDelay = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetRandomDelay()
    {
        _targetDelay =  Random.Range(_enemyAttacking.MinAttackDelay,_enemyAttacking.MaxAttackDelay);
    }

}
