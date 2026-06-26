using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Turner _turner;
    [SerializeField] private Patrol _patrol;

    private void Update()
    {
        _patrol.CheckDirection(transform.position);
        _mover.Move(_patrol.Direction);
        _turner.TryTurn(_patrol.Direction);
    }
}
