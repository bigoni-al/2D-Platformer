using System.Collections;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private LayerMask _ground;

    private bool _isGrounded;
    private float _radius = 0.5f;
    private float _delay = 0.2f;
    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_delay);
    }


    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CheckGrounding());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator CheckGrounding() 
    {
        while (enabled) 
        {
            _isGrounded = Physics2D.OverlapCircle(_transform.position, _radius, _ground);

            yield return _wait;
        } 
    }
}
