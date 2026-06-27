using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private float _direction = 1;
    private float _directionCoefficient = -1;
    private int _currentIndexWaypoint = 0;

    public float Direction => _direction;

    public void TryChangeDirection(Vector2 position)
    {
        if (_waypoints[_currentIndexWaypoint].transform.position.x < position.x && _direction > 0 ||
            _waypoints[_currentIndexWaypoint].transform.position.x > position.x && _direction < 0)
        {
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        _currentIndexWaypoint = (_currentIndexWaypoint + 1) % _waypoints.Length;
        _direction *= _directionCoefficient;
    }
}
