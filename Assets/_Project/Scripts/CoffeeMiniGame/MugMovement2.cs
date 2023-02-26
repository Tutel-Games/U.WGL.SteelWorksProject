using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugMovement2 : MonoBehaviour
{
    public PlayerInputs _inputs;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _inputs = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(_inputs.Horizontal * _speed, 0) * (Time.fixedDeltaTime * 100);
    }
}
