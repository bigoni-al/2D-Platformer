using UnityEngine;

public class Turner : MonoBehaviour
{
    private bool _isLookRight = true;
    private float _angleTurnRight = 0f;
    private float _angleTurnLeft = 180f;

    public void TryTurn(float direction)
    {
        if (_isLookRight == true && direction < 0)
        {
            _isLookRight = false;
            Turn(_angleTurnLeft);

        }
        else if (_isLookRight == false && direction > 0)
        {
            _isLookRight = true;
            Turn(_angleTurnRight);
        }
    }

    private void Turn(float rotationY)
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y = rotationY;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
