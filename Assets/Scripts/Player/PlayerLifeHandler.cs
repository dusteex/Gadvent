using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;
public class PlayerLifeHandler : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Color _hitColor = Color.red;

    private float _health;
    private  SpriteRenderer _spriteRenderer;
    void Start()
    {
        _health = _maxHealth;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        EventManager.HealthPowerUpEvent.AddListener(GetHP);
    }

    private void Fade()
    {
        Sequence s = DOTween.Sequence();
        s.Append(_spriteRenderer.DOColor(_hitColor,0.032f));
        s.Join(_spriteRenderer.DOFade(0.6f,0.032f));
        s.Append(_spriteRenderer.DOFade(1f,0.032f));
        s.Append(_spriteRenderer.DOColor(Color.white,0.032f));
    }

    private void GetHP(float upgradePercent)
    {
        _health += _maxHealth * upgradePercent / 100;
        if(_health > _maxHealth) _health = _maxHealth;
        EventManager.PlayerHPChanged.Invoke(_health/_maxHealth*100); 
    }

    public void  TakeDamage(float reduceValue)
    {
        _health -= reduceValue;
        Fade();
        EventManager.PlayerHPChanged.Invoke(_health/_maxHealth*100); 
        if(_health <= 0 ) Death();
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }
}
