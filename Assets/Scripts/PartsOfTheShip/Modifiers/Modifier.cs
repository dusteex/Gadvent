using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    [SerializeField] private string _modifierName;
    public string ModifierName => _modifierName;
    [SerializeField] private int _modifierLevel;
    public int ModifierLevel => _modifierLevel;

    [SerializeField] private double _reloadTime;    //sec
    public double ReloadTime => _reloadTime;
    [SerializeField] private double _durationTime;  //sec
    public double DurationTime => _durationTime;

    [SerializeField] private RarityTypes _modifierRarity;
    public RarityTypes ModifierRarity => _modifierRarity;

    [SerializeField] private Sprite[] _modifierSprite;
    public Sprite[] ModifierSprites => _modifierSprite;

    public abstract void Ability();


}
