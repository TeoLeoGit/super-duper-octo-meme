using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] GameObject _prefabLevel;
    public void StartNewLevel()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Instantiate(_prefabLevel, transform);
        GameController.OnStopAudio(SoundType.All);
        GameController.OnPlayAudio(SoundType.Background);

    }
}
