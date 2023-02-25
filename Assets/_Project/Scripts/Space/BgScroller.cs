using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    public float ScrollSpeed = 5f;
    private float _offset;
    private Material _mat;

    private void Awake()
    {
        _mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _offset += (Time.deltaTime * ScrollSpeed) / 10f;
        _mat.SetTextureOffset("_MainTex", new Vector2(0, _offset));
    }
}
