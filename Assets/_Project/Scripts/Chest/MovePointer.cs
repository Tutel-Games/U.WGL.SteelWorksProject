using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointer : MonoBehaviour
{
    [SerializeField] private Transform _posLeft;
    [SerializeField] private Transform _posRight;
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;
    private bool _isInField;
    
    [SerializeField] private AudioClip _good;
    [SerializeField] private AudioClip _bad;
    [SerializeField] private OpenChest _openChest;
    private AudioSource _as;
    private int _index;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    private void Start() 
    {
        pos1 = _posLeft.position;
        pos2 = _posRight.position;
    }
 
    private void Update () 
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isInField)
            {
                _as.PlayOneShot(_good);
                _openChest.Shake();
                _index++;
                if (_index == 3)
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                _as.PlayOneShot(_bad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Respawn"))
        {
            _isInField = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Respawn"))
        {
            _isInField = false;
        }
    }
}
