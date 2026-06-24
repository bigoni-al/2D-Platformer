using UnityEngine;

public class Turner : MonoBehaviour
{   
    private bool _isLookRight = true;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void TryTurn(float direction) 
    {
        if (_isLookRight == true && direction < 0)
        {
            _isLookRight = false;
            _renderer.flipX = true;
        }
        else if(_isLookRight == false && direction > 0)
        {
            _isLookRight = true;
            _renderer.flipX = false;
        }    
    }
}
