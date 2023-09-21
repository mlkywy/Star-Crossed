using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (HealthManager.Health == 0)
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        HealthManager.ResetHealth();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
