using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private List<GameObject> _waveEnemies;
    public List<GameObject> WaveEnemies => new List<GameObject>(_waveEnemies);
}
