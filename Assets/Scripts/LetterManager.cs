using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class LetterManager : MonoBehaviour
{
    [Header("Letter UI")]
    [SerializeField] private GameObject _letterPanel;
    [SerializeField] private Text _letterText;

    [Header("Options UI")]
    [SerializeField] private GameObject _respondWithText;
    [SerializeField] private GameObject[] _choices;
    private Text[] _choicesText;

    private Story _currentStory;
    private bool _letterIsPlaying;

    public bool LetterIsPlaying
    {
        get { return _letterIsPlaying; }
    }

    private static LetterManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Found more than one Letter Manager in the scene.");
        }
        _instance = this;
    }

    public static LetterManager GetInstance() 
    {
        return _instance;
    }

    private void Start()
    {
        _letterIsPlaying = false;
        _letterPanel.SetActive(false);

        _choicesText = new Text[_choices.Length];
        int index = 0;
        foreach (GameObject option in _choices)
        {
            _choicesText[index] = option.GetComponentInChildren<Text>();
            index++;
        }
    }

    private void Update()
    {
        if (!_letterIsPlaying)
        {
            return;
        }

        if (InputManager.GetInstance().GetSubmitPressed())
        {
            ContinueStory();
        }
    }

    public void EnterLetterMode(TextAsset inkJson)
    {
        _currentStory = new Story(inkJson.text);
        _letterIsPlaying = true;
        _letterPanel.SetActive(true);

        ContinueStory();
    }

    private void ExitLetterMode()
    {
        _letterIsPlaying = false;
        _letterPanel.SetActive(false);
        _letterText.text = string.Empty;
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _letterText.text = _currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitLetterMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;
        Debug.Log("Current Choices count: " + currentChoices.Count);

        if (currentChoices.Count > 0)
        {
            _respondWithText.SetActive(true);
        }
        else
        {
            _respondWithText.SetActive(false);
        }

        if (currentChoices.Count > _choices.Length)
        {
            Debug.LogError("More options were given than the UI can support. Number of options given: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            _choices[index].gameObject.SetActive(true);
            _choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < _choices.Length; i++)
        {
            _choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    public void MakeChoice(int choiceIndex)
    {
        Debug.Log("Choice made: " + choiceIndex);
        _currentStory.ChooseChoiceIndex(choiceIndex);
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(_choices[0].gameObject);
    }
}
