using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private List<GameObject> _offObjects;
    [SerializeField] private List<GameObject> _onObjects;
    [SerializeField] private ParticleSystem _shakeParticles;
    private float _duration = 0.15f;
    private int _hits;
    private AudioSource _as;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }

    [ContextMenu("TESTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT")]
    public void Open()
    {
        foreach (var obj in _offObjects)
        {
            obj.SetActive(false);
        }
        
        foreach (var obj in _onObjects)
        {
            obj.SetActive(true);
        }
        _as.Play();
    }

    public void Shake()
    {
        DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, 0, -15), _duration))
                .Append(transform.DORotate(new Vector3(0, 0, 15), _duration))
                .Append(transform.DORotate(new Vector3(0, 0, 0), _duration));
        _hits++;
        _shakeParticles.Play();
        if (_hits == 3)
        {
            Open();
        }
    }
}
