using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    public float ScrollSpeed = 5f;
    [SerializeField] private float _offset = 1;
    private Material _mat;
    private bool _shouldStop;

    private void Awake()
    {
        _mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (_shouldStop)
        {
            if (Math.Abs(Math.Floor(_offset) - _offset) < 0.01f) return;
            
            _offset += (Time.deltaTime * ScrollSpeed) / 10f;
            _mat.SetTextureOffset("_MainTex", new Vector2(0, _offset));
        }
        else
        {
            _offset += (Time.deltaTime * ScrollSpeed) / 10f;
            _mat.SetTextureOffset("_MainTex", new Vector2(0, _offset));
        }
        
    }

    public void Stop()
    {
        _shouldStop = true;
    }
}
