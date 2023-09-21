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

    private void OnTriggerEnter2D(Collider2D objectHit)
    {
        if (objectHit.tag != "Player")
        {
            if (objectHit.tag == "Enemy" || objectHit.tag == "Obstacle")
            {
                Destroy(objectHit.gameObject);
            }

            Destroy(this.gameObject);
        }
    }
}
