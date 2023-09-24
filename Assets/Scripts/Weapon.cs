using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;

    private void Update()
    {
        if (InputManager.GetInstance().GetShootPressed() && !GameOver.GameIsOver)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }
}
