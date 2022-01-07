using UnityEngine;

abstract public class EnemyShooting : EnemyAttacking
{
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected float _bulletSpeed;   
    [SerializeField] protected float _bulletDestroyTime;
    [SerializeField] protected Transform _muzzle;

    protected Transform _bulletsContainer;
    protected Pool<Bullet> _bulletsPool;

    private void Start()
    {
        _bulletsContainer = new GameObject().transform;
        _bulletsPool = new Pool<Bullet>(_bullet ,count: 10 , _bulletsContainer);
    }

    private void OnDestroy()
    {
        Destroy(_bulletsContainer.gameObject);
    }


    
}
