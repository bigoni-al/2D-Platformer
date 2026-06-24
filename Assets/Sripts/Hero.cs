using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Turner))]
public class Hero : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Turner _turner;
    [SerializeField] private Animator _animator;

    private bool _isGrounded;
    private readonly int IsRuning = Animator.StringToHash(nameof(IsRuning));

    private void OnEnable()
    {
        _inputReader.MovementAppointed += OrderMove;
        _inputReader.MovementSpopped += StopRunningAnimation;
        _inputReader.JumpAppointed += OrderJump;
    }

    private void OnDisable()
    {
        _inputReader.MovementAppointed -= OrderMove;
        _inputReader.JumpAppointed -= OrderJump;
        _inputReader.MovementSpopped -= StopRunningAnimation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform _))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform _))
        {
            _isGrounded = false;
        }
    }

    private void OrderMove(float direction) 
    {
        if (_isGrounded) 
        {     
            _mover.Move(direction);
            _turner.TryTurn(direction);
            _animator.SetBool(IsRuning, true);
        }    
    }

    private void OrderJump(float direction) 
    {
        if (_isGrounded) 
        {
            _jumper.Jump(direction, _mover.Speed);
            _animator.SetBool(IsRuning, false);
        }
    }

    private void StopRunningAnimation() 
    {
        _animator.SetBool(IsRuning, false);
    }
}