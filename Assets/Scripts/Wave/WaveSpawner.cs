using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// MUST BE CONNECTED TO SPAWN POINTS PARENT 

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _initialSpawnPlace;

    private List<Wave> _waves = new List<Wave>();
    private Wave _currentWave;
    private List<Transform> _spawnPlaces;
    private List<GameObject> _waveEnemies;

    

    private void Start()
    {
        //Dima is stupid a programmer! Because:

        //Заполняем _waves полностью, пробегаясь по всем дочерним объектам Waves(this.gameObject)
        foreach (Transform wavesChild in this.transform)
        {
            if (wavesChild.TryGetComponent<Wave>(out Wave wave))
            {
                _waves.Add(wave);
            }
        }

        StartNextWave();
    }

    [SerializeField] private float _moveTime = 0.5f;
    void StartNextWave()
    {
        if (_waves.Count != 0)
        {
            _currentWave = _waves[0];
            _waves.RemoveAt(0);//O(_waves.count - 0)
                               // Заполнение массива точек спавна
            _spawnPlaces = new List<Transform>();
            foreach (Transform child in _currentWave.transform) _spawnPlaces.Add(child);

            _waveEnemies = _currentWave.WaveEnemies;
            StartCoroutine(SetEnemies(0.1f, _moveTime));
        }
        else
        {
            //Делайте че хотите со своими сценами
        }
    }

    public void NotifyDeathEnemy(Vector3 spawnPosition)
    {
        if(_waveEnemies.Count != 0)
        {
            SetEnemy(spawnPosition, _moveTime);
        }
        else
        {
            StartNextWave();
        }
    }
    private IEnumerator<WaitForSeconds> SetEnemies(float delay, float moveTime)
    {
        // Если Врагов меньше, чем точек спавна, то спавним до тех пор пока не закончатся враги, иначе, пока не заполним все точки
        int spawnCount = _spawnPlaces.Count > _waveEnemies.Count ? _waveEnemies.Count : _spawnPlaces.Count;
        for (int i = 0; i < spawnCount; i++)
        {
            SetEnemy(_spawnPlaces[i].position, moveTime);

            yield return new WaitForSeconds(delay);
        }
    }
    private void SetEnemy(Vector3 spawnPosition, float moveTime)
    {
        GameObject enemy = Instantiate(_waveEnemies[0], _initialSpawnPlace.position, Quaternion.identity);
        enemy.transform.DOMove(spawnPosition, moveTime);

        EnemyLifeHandler enemyLifeHandler = enemy.GetComponent<EnemyLifeHandler>();
        enemyLifeHandler.SetSpawnPosition(spawnPosition);
        enemyLifeHandler.NotifyDeathEnemy = NotifyDeathEnemy;

        _waveEnemies.RemoveAt(0);
    }
}
