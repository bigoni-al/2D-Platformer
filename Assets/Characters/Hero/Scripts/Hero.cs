using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Turner))]
[RequireComponent(typeof(Bag))]
[RequireComponent(typeof(HeroRenderer))]
public class Hero : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private Turner _turner;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private HeroRenderer _heroRenderer;

    private void OnEnable()
    {
        _inputReader.MovementAppointed += OrderMove;
        _inputReader.JumpAppointed += OrderJump;    
    }

    private void OnDisable()
    {
        _inputReader.MovementAppointed -= OrderMove;
        _inputReader.JumpAppointed -= OrderJump;
    }

    private void OrderMove(float direction) 
    {
        if (_groundDetector.IsGrounded)
        {
            _mover.Move(direction);
            _turner.TryTurn(direction);
            _heroRenderer.DrawMove(direction);
        }
        else 
        {
            _heroRenderer.DrawIdle();
        }
    }

    private void OrderJump(float direction) 
    {
        if (_groundDetector.IsGrounded) 
        {
            _jumper.Jump(direction, _mover.Speed);
            _heroRenderer.DrawIdle();
        }
    }
}