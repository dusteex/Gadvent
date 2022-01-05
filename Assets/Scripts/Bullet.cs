using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _bulletSpeed;
    private float _damage;
    private bool _isPlayerBullet;
    private int _directionCoeff;
    private float _destroyTime;
    private Pool<Bullet> _pool;
    private bool _isInitialized;

    public void Initialization(float damage , float bulletSpeed , float bulletDestroyTime, bool isPlayerBullet , Pool<Bullet> pool)
    {
        if(_isInitialized == false)
        {
            _damage = damage;
            _bulletSpeed = bulletSpeed;
            _isPlayerBullet = isPlayerBullet;
            _directionCoeff = isPlayerBullet ? 1 : -1;
            _pool = pool;
            _isInitialized = true;
        }
        _destroyTime = bulletDestroyTime;

    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.zero;
    }

    void FixedUpdate()
    {                                                           //BAN direction
        _rb.velocity = new Vector2(_rb.velocity.x, _bulletSpeed * _directionCoeff);
        _destroyTime-=Time.deltaTime;
        if(_destroyTime <= 0 )
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(_isPlayerBullet && col.TryGetComponent<EnemyLifeHandler>(out EnemyLifeHandler enemy))
        {
            enemy.TakeDamage(_damage);
            DestroyBullet();
        }
        else if(_isPlayerBullet == false && col.TryGetComponent<PlayerLifeHandler>(out PlayerLifeHandler player))
        {
            player.TakeDamage(_damage);
            DestroyBullet();
        }
    }

    void DestroyBullet()
    { 
        gameObject.SetActive(false);
    }
}
