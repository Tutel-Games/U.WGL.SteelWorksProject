using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectVisualEffects : MonoBehaviour
{
    [SerializeField] private float _scaleUp = 0.5f;
    private Vector3 _scale;
    private void Start()
    {
        _scale = transform.localScale;
        var sequence = DOTween.Sequence()
            .Append(transform.DOScale(new Vector3(_scale.x + _scaleUp, _scale.y + _scaleUp, _scale.z + _scaleUp), 0.5f))
            .Append(transform.DOScale(_scale, 0.5f)).SetLoops(-1);
        sequence.Play();
    }
}
