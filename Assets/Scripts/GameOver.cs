using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    private static bool _gameIsOver;

    [SerializeField] private AudioClip _selectSound;
    [SerializeField] private AudioClip _backSound;
    [SerializeField] private AudioClip _moveBetweenSound;

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

            if (InputManager.GetInstance().GetMovePressed())
            {
                SoundManager.GetInstance().PlaySound(_moveBetweenSound);
            }
        }
    }

    public void RestartLevel()
    {
        UnfreezeGame();
        SoundManager.GetInstance().PlaySound(_selectSound);
        StartCoroutine(ChangeScenes(0.5f, SceneManager.GetActiveScene().name));
    }

    public void ReturnToMenu()
    {
        UnfreezeGame();
        SoundManager.GetInstance().PlaySound(_backSound);
        StartCoroutine(ChangeScenes(0.5f, "Main Menu"));
    }

    private void UnfreezeGame()
    {
        _gameIsOver = false;
        HealthManager.ResetHealth();
        Time.timeScale = 1;
    }

    private IEnumerator ChangeScenes(float transitionTime, string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
