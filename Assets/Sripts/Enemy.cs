using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Mover _mover;
    [SerializeField] private Turner _turner;

    private float _direction = 1;
    private float _directionCoefficient = -1;

    private int _currentIndexWaypoint = 0;

    private void Update()
    {
        _mover.Move(_direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Waitpoint _)) 
        {
            _currentIndexWaypoint = (_currentIndexWaypoint + 1) % _waypoints.Length;
            _direction *= _directionCoefficient;
            _turner.TryTurn(_direction);
        }
    }
}
