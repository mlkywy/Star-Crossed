using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    private static bool _gameIsOver;

    public static bool GameIsOver
    {
        get { return _gameIsOver; }
    }

    private void Start()
    {
        _gameIsOver = false;
        _gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (HealthManager.Health == 0)
        {
            _gameIsOver = true;
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        _gameIsOver = false;
        HealthManager.ResetHealth();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
