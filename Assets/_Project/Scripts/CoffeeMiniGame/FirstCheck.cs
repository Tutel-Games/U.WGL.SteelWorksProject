using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FirstCheck : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _particles;
    [SerializeField] private AudioSource _as;
    private bool _isStarted;
    private void Update()
    {
        if (_isStarted) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isStarted = true;
            _text.SetActive(false);
            _as.Play();
            StartCoroutine(StartParticles());
        }
    }

    private IEnumerator StartParticles()
    {
        DOTween.Sequence()
            .Append(transform.DORotate(new Vector3(0, 0, -15), 0.1f))
            .Append(transform.DORotate(new Vector3(0, 0, 15), 0.1f))
            .Append(transform.DORotate(new Vector3(0, 0, 0), 0.1f)).SetLoops(6, LoopType.Restart);
        yield return new WaitForSeconds(1.9f);
        _particles.SetActive(true);
    }

}
