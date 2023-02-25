using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPos;
    [SerializeField] private List<Transform> _destinations;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _timerStart = 4;
    [SerializeField] private float _timer = 4;
    private Random _rnd = new();

    private void Start()
    {
        _timer = _timerStart;
        SpawnEnemy(0);
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer = _timerStart;
            SpawnEnemy(_rnd.Next(0,3));
        }
    }

    private void SpawnEnemy(int index)
    {
        Instantiate(_enemyPrefab, _spawnPos[index].position, Quaternion.identity).GetComponent<SpaceEnemy>().Setup(_destinations[index]);
    }
}
