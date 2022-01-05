using UnityEngine;

public class BasicShooting : Shooting
{
    public override void Shoot()
    {
        foreach (Transform muzzle in gunParams.Muzzles)
        {
            Bullet bullet = _bulletsPool.GetElement();
            bullet.transform.position = muzzle.position;
            bullet.Initialization(damage: gunParams.Damage , bulletSpeed : gunParams.BulletSpeed, bulletDestroyTime:gunParams.BulletDestroyTime , isPlayerBullet:true , _bulletsPool );
        }
    }
}
