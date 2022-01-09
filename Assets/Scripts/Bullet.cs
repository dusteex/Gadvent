using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _bulletSpeed;
    private float _damage;
    private bool _isPlayerBullet;
    private Vector2 _direction;
    private float _destroyTime;
    private Pool<Bullet> _pool;
    private bool _isInitialized;
    private float _deviationX;
    private float _lifeTime;

    public void Initialization(float damage , float bulletSpeed , float bulletDestroyTime, bool isPlayerBullet , Pool<Bullet> pool , float angle)
    {
        if(_isInitialized == false)
        {
            _damage = damage;
            _bulletSpeed = bulletSpeed;
            _isPlayerBullet = isPlayerBullet;
            _pool = pool;
            _isInitialized = true;
        }
        _direction = new Vector2( Mathf.Cos((angle+90)*Mathf.PI/180) , Mathf.Sin((angle+90)*Mathf.PI/180) );
        //if(_isPlayerBullet) Debug.Log($"Direction : {_direction}");
        _destroyTime = bulletDestroyTime;
        _lifeTime = 0.1f;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {                                                           
        _rb.velocity = new Vector2(_direction.x*8, _direction.y*_bulletSpeed);
        
        if(_destroyTime <= _lifeTime )
        {
            DestroyBullet();
        }
    }

    void Update()
    {
        _lifeTime+= Time.deltaTime;
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
