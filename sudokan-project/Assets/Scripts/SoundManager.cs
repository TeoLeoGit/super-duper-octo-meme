using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _clipWalk;
    [SerializeField] AudioClip _clipBackground;
    [SerializeField] AudioClip _clipWin;

    [SerializeField] GameObject _audioSource;

    private void Awake()
    {
        PlaySound(SoundType.Background);
    }

    private void PlaySound(SoundType type)
    {
        var audioSource = Instantiate(_audioSource).GetComponent<AudioSource>();

        switch(type)
        {
            case SoundType.Walking:
                audioSource.clip = _clipWalk;
                break;
            case SoundType.Win:
                audioSource.clip = _clipWin;
                break;
            case SoundType.Background:
                audioSource.loop = true;
                audioSource.clip = _clipWin;
                break;
        }
        audioSource.Play();

    }
}

public enum SoundType
{
    Walking = 1,
    Background = 2,
    Win = 3,
}
