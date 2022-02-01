using UnityEngine;
using UnityEngine.Events;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerUpsArray;
    [SerializeField] private float _spawnChancePercent;
    static public UnityEvent<Vector3> PowerUpSpawnEvent = new UnityEvent<Vector3>();

    void Start()
    {
        PowerUpSpawnEvent.AddListener(TrySpawnPowerUp);
    }

    void TrySpawnPowerUp(Vector3 pos)
    {
        int rand = Random.Range(1,101);
        if(rand <= _spawnChancePercent) SpawnPowerUp(pos);
    }

    void SpawnPowerUp(Vector3 pos)
    {
        int rand = Random.Range(0,_powerUpsArray.Length); 
        Instantiate(_powerUpsArray[rand],pos,Quaternion.identity);
    }
}
