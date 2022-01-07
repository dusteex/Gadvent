using UnityEngine;
public class PlayerShootingController : MonoBehaviour
{
    private PlayerShooting _playerShooting;
    private float _currentDelay;

    private void Start()
    {
        _playerShooting = GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if (IsPlayerCanShoot()) _playerShooting.Shoot();

    }
    private bool IsPlayerCanShoot()
    {
        if(_currentDelay > _playerShooting.FiringDelay)
        {
            _currentDelay = 0;
            return true;
        }
        return false;
    }


}
  