using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _startTimeBetweenShots;
    private float _timeBetweenShots;

    [SerializeField] private GameObject _bullet;
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_timeBetweenShots <= 0)
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
            _timeBetweenShots = _startTimeBetweenShots;
        }
        else 
        {
            _timeBetweenShots -= Time.deltaTime;
        }
    }
}
