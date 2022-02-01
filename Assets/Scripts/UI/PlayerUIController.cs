using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;

    void Start()
    {
        EventManager.PlayerHPChanged.AddListener(ChangeHPBar);
    }

    private void ChangeHPBar(float percent) 
    {
        _hpBar.value = _hpBar.maxValue * percent/100;
    }

}
