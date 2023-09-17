using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
