using UnityEngine;

public class DamagePowerUp : PowerUp
{
    [SerializeField] private float _upgradePercent;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.TryGetComponent<PlayerLifeHandler>(out var lh))
        {
            EventManager.DamagePowerUpEvent.Invoke(_upgradePercent);
            Destroy(gameObject);
        }
    }
}
