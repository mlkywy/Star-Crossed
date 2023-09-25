using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] private AudioClip _music;

    private void Awake()
    {
        SoundManager.GetInstance().ChangeBGM(_music);
    }
}
