using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SliderFall : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    private float _speed = 3;
    private bool _start;
    [SerializeField] private AudioSource _as;
    [SerializeField] private GameObject _properSlider;
    [SerializeField] private GameObject _pressSpaceText;
    private void Awake()
    {
        _as.GetComponent<AudioSource>();
    }

    private void Start()
    {
        _as.Play();
    }

    private void Update()
    {
        float step = _speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _destination.transform.position, step);

        if (transform.position == _destination.position)
        {
            _pressSpaceText.SetActive(true);
            _properSlider.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
