using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPos;
    [SerializeField] private List<Transform> _destinations;
    [SerializeField] private GameObject _enemyPrefab;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPos[0].position, Quaternion.identity).GetComponent<SpaceEnemy>().Setup(_destinations[0]);
    }
}
