using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    private InputMaster _controls;

    private void Awake()
    {
        _controls = new InputMaster();
        _controls.Player.Shoot.performed += ctx => Shoot();
    }

    private void Shoot()
    {
        // Shooting Logic
        
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }
}
