using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class LetterManager : MonoBehaviour
{
    [Header("Letter UI")]
    [SerializeField] private GameObject _letterPanel;
    [SerializeField] private Text _letterText;
    [SerializeField] private GameObject _continueArrow;
    [SerializeField] private GameObject _backArrow;

    [Header("Options UI")]
    [SerializeField] private GameObject _respondWithText;
    [SerializeField] private GameObject[] _choices;
    private Text[] _choicesText;

    private Story _currentStory;
    private bool _letterIsPlaying;
    private bool _canRereadLetter;
    private bool _canRereadResponse;
    private string _responsePathString;

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

        if (InputManager.GetInstance().GetInteractPressed())
        {
            if (_canRereadLetter)
            {
                _currentStory.ChoosePathString("main");
            }
            
            if (_canRereadResponse)
            {
                _currentStory.ChoosePathString(_responsePathString);
            }
            
            ContinueStory();
        }
    }

    public void EnterLetterMode(TextAsset inkJson)
    {
        _canRereadLetter = true;
        _canRereadResponse = false;
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
            _continueArrow.SetActive(true);
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

        if (currentChoices.Count > 0)
        {
            _backArrow.SetActive(true);
            _continueArrow.SetActive(false);
            _respondWithText.SetActive(true);
        }
        else
        {
            _backArrow.SetActive(false);
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
    }

    public void MakeChoice(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        _canRereadLetter = false;
        _canRereadResponse = true;

        if (choiceIndex == 0)
        {
            _responsePathString = "option1";
        }
        else if (choiceIndex == 1)
        {
            _responsePathString = "option2";
        }
    }
}
