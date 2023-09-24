using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    // private InputMaster _controls;

    // private void Awake()
    // {
    //     _controls = new InputMaster();
    //     _controls.Player.Shoot.performed += ctx => Shoot();
    // }

    private void Update()
    {
        if (InputManager.GetInstance().GetShootPressed())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
    }

    // private void OnEnable()
    // {
    //     _controls.Player.Enable();
    // }

    // private void OnDisable()
    // {
    //     _controls.Player.Disable();
    // }
}
