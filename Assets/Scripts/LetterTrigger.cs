using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _visualCue;
    [SerializeField] private TextAsset _inkJson;
    private bool _characterInRange;

    private void Awake()
    {
        _characterInRange = false;
        _visualCue.SetActive(false);
    }

    private void Update()
    {
        if (_characterInRange && !LetterManager.GetInstance().LetterIsPlaying)
        {
            _visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed())
            {
                LetterManager.GetInstance().EnterLetterMode(_inkJson);
            }
        }
        else
        {
            _visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            _characterInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            _characterInRange = false;
        }
    }
}
