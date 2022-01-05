using UnityEngine;

public class PlayerLifeHandler : MonoBehaviour
{
    [SerializeField] private float _health;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void  TakeDamage(float reduceValue)
    {
        _health -= reduceValue;
        if(_health < 0 ) Death();
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
