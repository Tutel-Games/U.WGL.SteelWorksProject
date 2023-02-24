using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInputs))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private PlayerInputs _inputs;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputs = GetComponent<PlayerInputs>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_inputs.Horizontal * _speed, _inputs.Vertical * _speed) * (Time.fixedDeltaTime * 100);
    }
}
