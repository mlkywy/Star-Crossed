using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameObject _soundManager;
    [SerializeField] private AudioClip _playSound;
    [SerializeField] private AudioClip _selectSound;
    [SerializeField] private AudioClip _backSound;
    [SerializeField] private AudioClip _moveBetweenSound;

    private void Start()
    {
        _soundManager = GameObject.FindWithTag("SoundManager");
    }

    private void Update()
    {
        if (InputManager.GetInstance().GetMovePressed())
        {
            SoundManager.GetInstance().PlaySound(_moveBetweenSound);
        }
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SoundManager.GetInstance().PlaySound(_playSound);
        StartCoroutine(ChangeScenes(1.5f, "Level 1-0"));
        
    }

    public void ShowControls()
    {
        SoundManager.GetInstance().PlaySound(_selectSound);
        StartCoroutine(ChangeScenes(0.5f, "Controls"));
    }

    public void HideControls()
    {
        SoundManager.GetInstance().PlaySound(_backSound);
        StartCoroutine(ChangeScenes(0.5f, "Main Menu"));
    }

    private IEnumerator ChangeScenes(float transitionTime, string sceneName)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
