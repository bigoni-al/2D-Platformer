using UnityEngine;

public class HeroRenderer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _directionMin = 0.2f;
    private readonly int IsRuning = Animator.StringToHash(nameof(IsRuning));

    public void DrawMove(float direction)
    {
        if (Mathf.Abs(direction) > _directionMin)
        {
            _animator.SetBool(IsRuning, true);
        }
        else
        {
            _animator.SetBool(IsRuning, false);
        }
    }

    public void DrawIdle()
    {
        _animator.SetBool(IsRuning, false);
    }
}
