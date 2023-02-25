using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemy : MonoBehaviour
{
    [SerializeField] private Transform _moveTowards;
    [SerializeField] private float _speed = 5; 
    
    public void Setup(Transform moveTowards)
    {
        _moveTowards = moveTowards;
    }
    
    private void Update()
    {
        float step = _speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _moveTowards.position, step);
    }
}
