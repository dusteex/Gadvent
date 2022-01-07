using UnityEngine;

abstract public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] protected float _minAttackDelay;
    [SerializeField] protected float _maxAttackDelay;
    [SerializeField] protected float _damage;

    public float MinAttackDelay => _minAttackDelay;
    public float MaxAttackDelay => _maxAttackDelay;

    abstract public void Attack();
}
