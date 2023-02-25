using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectVisualEffects : MonoBehaviour
{
    private void Start()
    {
        var sequence = DOTween.Sequence()
            .Append(transform.DOScale(new Vector3(1 + 0.5f, 1 + 0.5f, 1 + 0.5f), 0.5f))
            .Append(transform.DOScale(1, 0.5f)).SetLoops(-1);
        sequence.Play();
    }
}
