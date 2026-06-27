using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Turner _turner;
    [SerializeField] private Patrol _patrol;

    private void Update()
    {
        _patrol.TryChangeDirection(transform.position);
        _turner.TryTurn(_patrol.Direction);
        _mover.Move(_patrol.Direction);    
    }
}
