using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _characterSpeed = 8f;
    private Rigidbody2D _rb;
    private float _directionX;
    private bool _isFacingRight;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        if (LetterManager.GetInstance().LetterIsPlaying)
        {
            return;
        }

        _rb.velocity = new Vector2(_directionX * _characterSpeed, _rb.velocity.y);
    }

    private void Flip()
    {
        if ((_isFacingRight && _directionX < 0f || !_isFacingRight && _directionX > 0f) && !LetterManager.GetInstance().LetterIsPlaying)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
