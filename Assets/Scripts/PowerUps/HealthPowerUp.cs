using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField] private float _upgradePercent;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent<PlayerLifeHandler>(out var lh))
        {
            EventManager.HealthPowerUpEvent.Invoke(_upgradePercent);
            Destroy(gameObject);
        }
    }
}
