using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    public void Move(float direction)
    {
        direction = Mathf.Abs(direction);
        float distance = direction * _speed * Time.deltaTime;
        transform.Translate(distance * Vector2.right);
    }
}