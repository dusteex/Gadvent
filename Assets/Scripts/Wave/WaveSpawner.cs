using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.SceneManagement;

// MUST BE CONNECTED TO SPAWN POINTS PARENT 

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _initialSpawnPlace;
    [SerializeField] private Transform _leftTopLimiter;
    [SerializeField] private Transform _rightBottomLimiter;

    private List<Wave> _waves = new List<Wave>();
    private Wave _currentWave;
    private List<Transform> _spawnPlaces;
    private List<GameObject> _waveEnemies;

    static public UnityEvent<bool> EnemiesSetEvent = new UnityEvent<bool>();


    private void Start()
    {
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    [SerializeField]
    private float waveStartDelay = 1.5f;
     
    private int _numberEnemies = 0;
    public void TrySpawnEnemy(Vector3 spawnPosition)
    {
        _numberEnemies--;
        if (_waveEnemies.Count != 0)
        {
            SetEnemy(spawnPosition, _moveTime);
            return;
        }
        
        if(_numberEnemies == 0)
        {
            Invoke("StartNextWave", waveStartDelay);
            EnemiesSetEvent.Invoke(false);
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
        EnemiesSetEvent.Invoke(true);
    }
    private void SetEnemy(Vector3 spawnPosition, float moveTime)
    {
        GameObject enemy = Instantiate(_waveEnemies[0], _initialSpawnPlace.position, Quaternion.identity);

        _numberEnemies++;

        enemy.transform.DOMove(spawnPosition, moveTime);
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        StartCoroutine(enemyMovement.SetMove(moveTime,_leftTopLimiter.position,_rightBottomLimiter.position));

        EnemyLifeHandler enemyLifeHandler = enemy.GetComponent<EnemyLifeHandler>();
        enemyLifeHandler.SetSpawnPosition(spawnPosition);
        enemyLifeHandler.NotifyDeathEnemy = TrySpawnEnemy;

        _waveEnemies.RemoveAt(0);
    }
}
