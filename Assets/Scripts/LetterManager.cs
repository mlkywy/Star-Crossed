using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class LetterManager : MonoBehaviour
{
    [Header("Letter UI")]
    [SerializeField] private GameObject _letterPanel;
    [SerializeField] private Text _letterText;
    [SerializeField] private GameObject _continueArrow;

    [Header("Options UI")]
    [SerializeField] private GameObject _respondWithText;
    [SerializeField] private GameObject _sendLetterText;
    [SerializeField] private GameObject[] _choices;
    private Text[] _choicesText;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset _loadGlobalsJson;

    private Story _currentStory;
    private bool _letterIsPlaying;
    private List<Choice> _currentChoices;

    public bool LetterIsPlaying
    {
        get { return _letterIsPlaying; }
    }

    private LetterVariables _letterVariables;

    private static LetterManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Found more than one Letter Manager in the scene.");
        }
        _instance = this;

        _letterVariables = new LetterVariables(_loadGlobalsJson);
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
        _sendLetterText.SetActive(false);
        _respondWithText.SetActive(false);
        _currentStory = new Story(inkJson.text);
        _letterIsPlaying = true;
        _letterPanel.SetActive(true);

        _letterVariables.StartListening(_currentStory);

        ContinueStory();
    }

    private void ExitLetterMode()
    {
        _letterVariables.StopListening(_currentStory);

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
        _currentChoices = _currentStory.currentChoices;

        if (_currentChoices.Count > 0)
        {
            _continueArrow.SetActive(false);

            bool sendLetter = ((Ink.Runtime.BoolValue) GetVariableState("sendLetter")).value;
            if (sendLetter)
            {
                _sendLetterText.SetActive(true);
                _respondWithText.SetActive(false);
            }
            else
            {
                _sendLetterText.SetActive(false);
                _respondWithText.SetActive(true);
            }
        }
        else
        {
            _sendLetterText.SetActive(false);
            _respondWithText.SetActive(false);
        }

        if (_currentChoices.Count > _choices.Length)
        {
            Debug.LogError("More options were given than the UI can support. Number of options given: " + _currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in _currentChoices)
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

        // handle scene transition
        if (_currentChoices[choiceIndex].text == "yes")
        {
            ExitLetterMode();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (_currentChoices[choiceIndex].text == "no")
        {
            ExitLetterMode();
        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        _letterVariables.Variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        
        return variableValue;
    }
}
