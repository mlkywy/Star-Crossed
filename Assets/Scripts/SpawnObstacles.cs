using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacles;
    [SerializeField] private float _maxX, _minX, _maxY, _minY, _timeBetweenSpawn;
    private float _spawnTime;

    private void Update()
    {
        if (Time.time > _spawnTime)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawn;
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);
        GameObject randomObstacle = _obstacles[Random.Range(0, _obstacles.Length)];

        Instantiate(randomObstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
