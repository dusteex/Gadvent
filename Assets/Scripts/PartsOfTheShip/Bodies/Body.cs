using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] protected string _bodyName;
    [SerializeField] protected int _bodyStrength;
    [SerializeField] protected int _bodyWeight;
    [SerializeField] private RarityTypes _bodyRarity;

    public string BodyName => _bodyName;
    public int BodyStrength => _bodyStrength;
    public int BodyWeight => _bodyWeight;
    public RarityTypes BodyRarity => _bodyRarity;
    
}


