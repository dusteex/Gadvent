using UnityEngine;
public class PlayerShootingHandler : MonoBehaviour
{
    private Shooting _shootingType;
    private float _currentDelay;

    private void Start()
    {
        _shootingType = GetComponent<Shooting>();
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if (IsPlayerCanShoot()) _shootingType.Shoot();

    }
    private bool IsPlayerCanShoot()
    {
        if(_currentDelay > _shootingType.gunParams.FiringDelay)
        {
            _currentDelay = 0;
            return true;
        }
        return false;
    }


}
  