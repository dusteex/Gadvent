using UnityEngine;

public class ModifierHandler : MonoBehaviour
{
    private Modifier _modifier;
    public Modifier GetModifier => _modifier;

    private void Start()
    {
        _modifier = GetComponent<Modifier>();
    }
}
