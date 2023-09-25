using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJSON;

    private void Start()
    {
        if (!LetterManager.GetInstance().LetterIsPlaying)
        {
            LetterManager.GetInstance().EnterLetterMode(_inkJSON);
        }
    }

    private void Update()
    {
        if (InputManager.GetInstance().GetSubmitPressed() && !LetterManager.GetInstance().LetterIsPlaying)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
