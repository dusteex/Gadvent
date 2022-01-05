using System.Collections.Generic;
using UnityEngine;

public class GunParams: MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private float _firingDelay;
    [SerializeField] private float _damage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDestroyTime;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private RarityTypes _rarityType;
    [SerializeField] private List<Transform> _muzzles;
    [SerializeField] private Transform _bulletsContainer;

    public string Name => _name;
    public float FiringDelay => _firingDelay;
    public float Damage => _damage;
    public float BulletSpeed => _bulletSpeed;
    public float BulletDestroyTime => _bulletDestroyTime;
    public RarityTypes RarityType => _rarityType;
    public Bullet Bullet => _bullet;
    public List<Transform> Muzzles => _muzzles;
    public Transform BulletsContainer => _bulletsContainer;
}
