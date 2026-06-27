using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _forceJump;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(float direction, float speed)
    { 
        _rigidbody.AddForce(new Vector2(direction * speed, _forceJump), ForceMode2D.Impulse);
    }
}
