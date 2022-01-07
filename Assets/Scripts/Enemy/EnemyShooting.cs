using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyTypes _enemyType;
    [Header("Bullet prefab")]
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _damage;
    [SerializeField] private float _bulletSpeed;   
    [SerializeField] private float _firingDelay;   
    [SerializeField] private float _bulletDestroyTime;
    private Transform _bulletsContainer;

    private Pool<Bullet> _bulletsPool;
    private Transform _muzzle;
    private float _currentDelay;

    private void Start()
    {
        _bulletsContainer = new GameObject().transform;
        _muzzle = transform.GetChild(0);
        _bulletsPool = new Pool<Bullet>(_bullet ,count: 10 , _bulletsContainer);
    }

    void Update()
    {
        _currentDelay+=Time.deltaTime;
        if(IsEnemyCanShoot())
        {
            switch(_enemyType)
            {
                case EnemyTypes.Default:
                    DefaultShooting();break;
            }
        }

    }
    private void OnDestroy()
    {
        Destroy(_bulletsContainer.gameObject);
    }

    void DefaultShooting()
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = _muzzle.position;
        bullet.Initialization(damage: _damage , bulletSpeed : _bulletSpeed , bulletDestroyTime:_bulletDestroyTime, isPlayerBullet:false , pool:_bulletsPool);
    }

    private bool IsEnemyCanShoot()
    {
        if(_currentDelay > _firingDelay)
        {
            _currentDelay = 0;
            return true;
        }
        return false;
    }
}
