using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpaceEnemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Transform _moveTowards;
    [SerializeField] private AudioSource _as;
    private SpaceManager _sm;
    [SerializeField] private ParticleSystem _explosionParticles;
    private void Awake()
    {
        _as = GameObject.Find("BoomSound").GetComponent<AudioSource>();
        _sm = FindObjectOfType<SpaceManager>();
    }

    public void Setup(Transform moveTowards)
    {
        _moveTowards = moveTowards;
    }
    
    private void Update()
    {
        float step = _speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _moveTowards.position, step);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Finish") || col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Root"))
        {
            _as.Play();
            _sm.AddScore();
            ParticleSystem explosion = Instantiate(_explosionParticles, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            explosion.Play();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
