using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyShooting : EnemyShooting
{

    public override void Attack()
    {
        Bullet bullet = _bulletsPool.GetElement();
        bullet.transform.position = _muzzle.position;
        bullet.Initialization(damage: _damage , bulletSpeed : _bulletSpeed , bulletDestroyTime:_bulletDestroyTime, isPlayerBullet:false , pool:_bulletsPool);
    }

}
