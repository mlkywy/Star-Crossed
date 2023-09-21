using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _hearts;
    private static int _health = 3;

    public static int Health
    {
        get { return _health; }
    }

    private void Start()
    {
        foreach (var heart in _hearts)
        {
            heart.SetActive(true);
        }
    }

    private void Update()
    {
        _health = Mathf.Clamp(_health, 0, 3);
        for (int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i].SetActive(i < _health);
        }
    }

    public static void TakeDamage()
    {
        _health -= 1;
    }

    public static void ResetHealth()
    {
        _health = 3;
    }
}
