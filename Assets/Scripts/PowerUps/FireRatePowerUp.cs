using UnityEngine;

public class FireRatePowerUp : PowerUp
{
    [SerializeField] private float _upgradePercent;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent<PlayerLifeHandler>(out var lh))
        {
            EventManager.FireRatePowerUpEvent.Invoke(_upgradePercent);
            Destroy(gameObject);
        }
    }
}
