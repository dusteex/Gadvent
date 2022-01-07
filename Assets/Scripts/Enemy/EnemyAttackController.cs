using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private EnemyAttacking _enemyAttacking;
    private float _currentDelay;

    private void Start()
    {
        _enemyAttacking = GetComponent<EnemyAttacking>();
    }

    void Update()
    {
        _currentDelay+=Time.deltaTime;
        if(isEnemyCanAttack()) _enemyAttacking.Attack();
    }

    private bool isEnemyCanAttack()
    {
        if(_currentDelay >= _enemyAttacking.AttackDelay )
        {
            _currentDelay = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
