using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShot : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    [SerializeField] private Transform _shotPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }
    
    private void SpawnEnemy()
    {
        Instantiate(_prefab, _shotPos.position, Quaternion.identity);
    }
}
