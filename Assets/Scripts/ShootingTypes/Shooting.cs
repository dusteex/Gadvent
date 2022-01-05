using UnityEngine;

abstract public class Shooting : MonoBehaviour
{
    public GunParams gunParams{private set ; get;}
    protected Pool<Bullet> _bulletsPool;
    
    abstract public void Shoot();

    private void Start()
    {
        gunParams = GetComponent<GunParams>();
        _bulletsPool = new Pool<Bullet>(gunParams.Bullet,1,gunParams.BulletsContainer);
    }
}
