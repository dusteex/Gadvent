using UnityEngine.Events;

static public class EventManager
{
    static public UnityEvent<float> FireRatePowerUpEvent = new UnityEvent<float>();
    static public UnityEvent<float> DamagePowerUpEvent = new UnityEvent<float>();
    static public UnityEvent<float> HealthPowerUpEvent = new UnityEvent<float>();
    static public UnityEvent<float> PlayerHPChanged = new UnityEvent<float>();
    static public UnityEvent ShootingPowerUpEvent = new UnityEvent();

}
