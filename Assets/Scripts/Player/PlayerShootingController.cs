using UnityEngine;
public class PlayerShootingController : MonoBehaviour
{
    private PlayerShooting _playerShooting;
    private float _currentDelay;
    private bool _enemiesSet = false;

    private void StartShoot(bool condition)
    {
        _enemiesSet = condition;
    }

    private void Start()
    {
        _playerShooting = GetComponent<PlayerShooting>();
        WaveSpawner.EnemiesSetEvent.AddListener(StartShoot);
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if (IsPlayerCanShoot()) 
        {
            SoundEventManager.GunSoundEvent.Invoke(_playerShooting.ShootSounds);
            _playerShooting.Shoot();
        };

    }
    private bool IsPlayerCanShoot()
    {
        if(_currentDelay > _playerShooting.FiringDelay && _enemiesSet)
        {
            _currentDelay = 0;
            return true;
        }
        return false;
    }


}
  