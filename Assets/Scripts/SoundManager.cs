using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;
    public AudioSource _source;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Found more than one Sound Manager in the scene.");
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this);

        _source = GetComponent<AudioSource>();
    }

    public static SoundManager GetInstance() 
    {
        return _instance;
    }

    public void PlaySound(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }

    public void ChangeBGM(AudioClip music)
    {
        if (_source.clip.name == music.name) 
        {
            return;
        }

        _source.Stop();
        _source.clip = music;
        _source.Play();
    }

    public void StopMusic()
    {
        _source.Stop();
    }
}
