using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    private Rigidbody2D _rb;
    private Vector2 _playerDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");

        _playerDirection = new Vector2(directionX, directionY).normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_playerDirection.x * _playerSpeed, _playerDirection.y * _playerSpeed);
    }
}
