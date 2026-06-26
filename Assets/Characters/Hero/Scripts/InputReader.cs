using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    public event Action<float> MovementAppointed;
    public event Action<float> JumpAppointed;
    
    private void Update()
    {
        ReadMovement();
        ReadJump();
    }

    private void ReadMovement() 
    {
        if (Input.GetAxis(Horizontal) != 0)
        {
            float direction = Input.GetAxis(Horizontal);
            MovementAppointed?.Invoke(direction);
        }
    }

    private void ReadJump() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            JumpAppointed?.Invoke(Input.GetAxis(Horizontal));
        }
    }
}
