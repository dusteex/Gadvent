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
    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] private AudioClip[] _shootSounds;

    private Transform _bulletsContainer;

    public AudioClip[] ShootSounds => _shootSounds;
    public float FiringDelay => _firingDelay;
    public float Damage => _damage;
    public float BulletSpeed => _bulletSpeed;
    public float BulletDestroyTime => _bulletDestroyTime;
    public RarityTypes RarityType => _rarityType;
    public Bullet Bullet => _bullet;
    public Transform Muzzle => _muzzleTransform;
    public Transform BulletsContainer => _bulletsContainer;
    
    private int _level = 1;
    private Pool<Bullet> _bulletsPool;
    public Action Shoot {get;private set;}
    private Action[] ShootsByLevel;

    private const int MAXLEVEL = 5;

    private void Start()
    {
        EventManager.FireRatePowerUpEvent.AddListener(upgradePercent=>
        {
            _firingDelay-= _firingDelay * upgradePercent/100;
        });

        EventManager.DamagePowerUpEvent.AddListener(upgradePercent=>
        {
            _damage += _damage * upgradePercent/100;
        });

        EventManager.ShootingPowerUpEvent.AddListener(LevelUp);

        Action[] ShootsByLevel = {Shoot1,Shoot2,Shoot3,Shoot4,Shoot5};
        this.ShootsByLevel = ShootsByLevel;
        _bulletsContainer = new GameObject().transform;
        _bulletsPool = new Pool<Bullet>(_bullet,1,_bulletsContainer);
        Shoot = ShootsByLevel[0];
    }

    private void Shoot1()
    {
        SpawnBullet(_muzzleTransform.position);
    }
    private void Shoot2()
    {
        SpawnBullet(_muzzleTransform.position + new Vector3(0.03f,0),-2);
        SpawnBullet(_muzzleTransform.position - new Vector3(0.03f,0),2);

    }private void Shoot3()
    {
        SpawnBullet(_muzzleTransform.position + new Vector3(0.05f,0),-2);
        SpawnBullet(_muzzleTransform.position - new Vector3(0.05f,0),2);
        SpawnBullet(_muzzleTransform.position);

    }private void Shoot4()
    {
        SpawnBullet(_muzzleTransform.position + new Vector3(0.07f,0),-3);
        SpawnBullet(_muzzleTransform.position - new Vector3(0.07f,0),3);
        SpawnBullet(_muzzleTransform.position + new Vector3(0.05f,0),-2);
        SpawnBullet(_muzzleTransform.position - new Vector3(0.05f,0),2);
        SpawnBullet(_muzzleTransform.position);

    }private void Shoot5()
    {
        SpawnBullet(_muzzleTransform.position + new Vector3(0.09f,0),-5);
        SpawnBullet(_muzzleTransform.position - new Vector3(0.09f,0),5);
        SpawnBullet(_muzzleTransform.position + new Vector3(0.07f,0),-3);
        SpawnBullet(_muzzleTransform.position - new Vector3(0.07f,0),3);
        SpawnBullet(_muzzleTransform.position + new Vector3(0.05f,0),-2);
        SpawnBullet(_muzzleTransform.position - new Vector3(0.05f,0),2);
        SpawnBullet(_muzzleTransform.position);
    }

    private void SpawnBullet(Vector3 pos,float angle = 0)
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = pos;
        bullet.transform.rotation = Quaternion.Euler(0,0,angle);
        bullet.Initialization(_damage ,_bulletSpeed,_bulletDestroyTime , isPlayerBullet:true , _bulletsPool , angle );
    }

    public void LevelUp()
    {
        if(_level >= MAXLEVEL) {
            return; // NEEDS TO CHANGE
        } 
        _level++;
        Shoot = ShootsByLevel[_level-1];
    }

}
