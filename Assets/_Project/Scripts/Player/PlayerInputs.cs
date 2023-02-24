using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    private readonly float _moveLimiter = 0.7f;

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        
        if (Horizontal != 0 && Vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            Horizontal *= _moveLimiter;
            Vertical *= _moveLimiter; 
        }
    }
}
