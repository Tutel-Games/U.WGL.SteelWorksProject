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
    [SerializeField] private float _timer = 0;
    [SerializeField] private GameObject _obj;
    private Random _rnd = new();
    
    private bool _shouldSpawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shouldSpawn = true;
            _obj.SetActive(false);
        }

        if (!_shouldSpawn) return;
        
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
