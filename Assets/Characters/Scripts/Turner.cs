using UnityEngine;

public class Turner : MonoBehaviour
{
    private Quaternion _rightRotation;
    private Quaternion _leftRotation;
    private bool _isLookRight = true; 

    private void Awake()
    {
        _rightRotation = transform.rotation;
        _leftRotation = AppointLeftRotation();
    }

    public void TryTurn(float direction)
    {
        if (_isLookRight == true && direction < 0)
        {
            _isLookRight = false;
            transform.rotation = _leftRotation;

        }
        else if (_isLookRight == false && direction > 0)
        {
            _isLookRight = true;
            transform.rotation = _rightRotation;
        }
    }

    private Quaternion AppointLeftRotation()
    {
        float angleTurnLeft = 180f;
        Vector3 rotation = transform.eulerAngles;
        rotation.y = angleTurnLeft;

        return Quaternion.Euler(rotation);
    }
}
