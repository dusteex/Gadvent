using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeHandler : MonoBehaviour
{
    [SerializeField] private float _health;
    void Start()
    {
        EventManager.HealthPowerUpEvent.AddListener(upgradePercent=>
        {
            _health += _health * upgradePercent / 100;
        });
    }


    public void  TakeDamage(float reduceValue)
    {
        _health -= reduceValue;
        if(_health < 0 ) Death();
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }
}
