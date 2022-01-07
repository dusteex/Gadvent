using UnityEngine;
using System;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float _firingDelay;
    [SerializeField] private float _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDestroyTime;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private RarityTypes _rarityType;
    [SerializeField] private Transform _muzzle;
    private Transform _bulletsContainer;

    public float FiringDelay => _firingDelay;
    public float Damage => _damage;
    public float BulletSpeed => _bulletSpeed;
    public float BulletDestroyTime => _bulletDestroyTime;
    public RarityTypes RarityType => _rarityType;
    public Bullet Bullet => _bullet;
    public Transform Muzzle => _muzzle;
    public Transform BulletsContainer => _bulletsContainer;
    
    private int _level = 1;
    private Pool<Bullet> _bulletsPool;
    public Action Shoot {get;private set;}
    private Action[] ShootsByLevel;

    private const int MAXLEVEL = 5;

    private void Start()
    {
        Action[] ShootsByLevel = {Shoot1,Shoot2,Shoot3,Shoot4,Shoot5};
        this.ShootsByLevel = ShootsByLevel;
        _bulletsContainer = new GameObject().transform;
        _bulletsPool = new Pool<Bullet>(_bullet,1,_bulletsContainer);
        Shoot = ShootsByLevel[0];
    }

    private void Shoot1()
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = _muzzle.position;
        bullet.Initialization(_damage ,_bulletSpeed,_bulletDestroyTime , isPlayerBullet:true , _bulletsPool );
    }
    private void Shoot2()
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = _muzzle.position;
        bullet.Initialization(_damage ,_bulletSpeed,_bulletDestroyTime , isPlayerBullet:true , _bulletsPool );
    }private void Shoot3()
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = _muzzle.position;
        bullet.Initialization(_damage ,_bulletSpeed,_bulletDestroyTime , isPlayerBullet:true , _bulletsPool );
    }private void Shoot4()
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = _muzzle.position;
        bullet.Initialization(_damage ,_bulletSpeed,_bulletDestroyTime , isPlayerBullet:true , _bulletsPool );
    }private void Shoot5()
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = _muzzle.position;
        bullet.Initialization(_damage ,_bulletSpeed,_bulletDestroyTime , isPlayerBullet:true , _bulletsPool );
    }

    public void LevelUp()
    {
        if(_level >= MAXLEVEL) {
            throw new Exception("Gun already have max Level");
        } 
        _level++;
        Shoot = ShootsByLevel[_level-1];
    }

}
