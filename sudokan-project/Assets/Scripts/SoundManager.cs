using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _clipWalk;
    [SerializeField] AudioClip _clipBackground;
    [SerializeField] AudioClip _clipWin;

    [SerializeField] GameObject _audioSource;
    GameObject _bgSource = null;

    private void Awake()
    {
        GameController.onPlayAudio += PlaySound;
        GameController.onStopAudio += StopSound;
    }

    private void OnDestroy()
    {
        GameController.onPlayAudio -= PlaySound;
        GameController.onStopAudio -= StopSound;
    }
    private void PlaySound(SoundType type)
    {
        var audioSource = Instantiate(_audioSource, transform).GetComponent<AudioSource>();

        switch(type)
        {
            case SoundType.Walking:
                audioSource.clip = _clipWalk;
                break;
            case SoundType.Win:
                audioSource.clip = _clipWin;
                break;
            case SoundType.Background:
                if (_bgSource != null) 
                {
                    Destroy(audioSource.gameObject);
                    return;
                }
                _bgSource = audioSource.gameObject;
                audioSource.loop = true;
                audioSource.clip = _clipBackground;
                break;
        }
        audioSource.Play();
    }

    private void StopSound(SoundType type)
    {
        switch (type)
        {
            case SoundType.Background:
                Destroy(_bgSource);
                break;
            case SoundType.All:
                for (int i = transform.childCount - 1; i > 0; i--)
                    Destroy(transform.GetChild(i).gameObject);
                break;
        }
    }
}

public enum SoundType
{
    Walking = 1,
    Background = 2,
    Win = 3,
    All = 99,
}
