using System;
using UnityEngine;
using DG.Tweening;
public class EnemyLifeHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _health;
    [SerializeField] private Color _hitColor = Color.red;
    [SerializeField] private AudioClip[] _deathSounds;
    private bool _death = false;

    private Vector3 _spawnPosition;
    bool _spawnPointInitialized = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSpawnPosition(Vector3 spawnPosition)
    {
        if(_spawnPointInitialized == false)
        {
            _spawnPosition = spawnPosition;
            _spawnPointInitialized = true;
        }
    }

    public void TakeDamage(float reduceValue)
    {
        _health -= reduceValue;
        Fade();
        if(_health <= 0 && _death == false) Death();
    }

    private void Fade()
    {
        Sequence s = DOTween.Sequence();
        s.Append(_spriteRenderer.DOColor(_hitColor,0.032f));
        s.Join(_spriteRenderer.DOFade(0.6f,0.032f));
        s.Append(_spriteRenderer.DOFade(1f,0.032f));
        s.Append(_spriteRenderer.DOColor(Color.white,0.032f));

    }


    public Action<Vector3> NotifyDeathEnemy;
    private void Death()
    {
        _death = true;
        PowerUpSpawner.PowerUpSpawnEvent.Invoke(transform.position);
        SoundEventManager.EnemyDeathSoundEvent.Invoke(_deathSounds);
        Destroy(gameObject);
        NotifyDeathEnemy.Invoke(_spawnPosition);
    }

}
