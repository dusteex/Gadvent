using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;   
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(0,-_moveSpeed);
    }
}
