using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnBorder"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            SoundManager.GetInstance().PlaySound(_hitSound);
            Destroy(this.gameObject);
            HealthManager.TakeDamage();
        }
    }
}
