using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpawnBorder")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            HealthManager.TakeDamage();
        }
    }
}
