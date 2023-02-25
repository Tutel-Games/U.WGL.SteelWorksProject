using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update ()
    {
        transform.Rotate (0,0,_speed*Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
