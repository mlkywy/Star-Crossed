using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject _visualCue;

    private bool _playerInRange;

    private void Awake()
    {
        _visualCue.SetActive(false);
    }
}
