using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float _currentTime = 0f;
    [SerializeField] private float _startingTime = 10f;
    [SerializeField] private Text _countdownTimerText;

    private void Start()
    {
        _currentTime = _startingTime;
        _countdownTimerText.text = _startingTime.ToString("0") + ":00";
    }

    private void Update()
    {
        _currentTime -= 1 * Time.deltaTime;
        _countdownTimerText.text = _currentTime.ToString("0") + ":00";

        if (_currentTime <= 0)
        {
            _currentTime = 0;
            if (HealthManager.Health > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
