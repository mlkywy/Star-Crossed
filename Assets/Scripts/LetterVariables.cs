using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class LetterVariables 
{
    private Dictionary<string, Ink.Runtime.Object> _variables;

    public Dictionary<string, Ink.Runtime.Object> Variables
    {
        get { return _variables; }
    }
    
    public LetterVariables(TextAsset loadGlobalsJson)
    {
        // compile the story
        Story globalVariablesStory = new Story(loadGlobalsJson.text);

        // initialize the dictionary
        _variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            _variables.Add(name, value);
            Debug.Log("Initialized global letter variable: " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (_variables.ContainsKey(name))
        {
            _variables.Remove(name);
            _variables.Add(name, value);
        }

        Debug.Log("Variable changed: " + name + " = " + value);
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in _variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
