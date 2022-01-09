using UnityEngine;

public class ShootingPowerUp : PowerUp
{
    [SerializeField] private float _upgradePercent;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent<PlayerLifeHandler>(out var lh))
        {
            EventManager.ShootingPowerUpEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
