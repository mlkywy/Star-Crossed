using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 20;
    [SerializeField] private Rigidbody2D _rb;

    private void Start()
    {
        _rb.velocity = transform.right * _bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
