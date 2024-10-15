using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    [SerializeField] GameObject _prefabLevel;
    [SerializeField] GameObject _popupWin;


    private void Awake()
    {
        GameController.onLevelComplete += OnLevelCompleted;
    }

    private void OnDestroy()
    {
        GameController.onLevelComplete -= OnLevelCompleted;
    }

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

    private void OnLevelCompleted()
    {
        _popupWin.SetActive(true);
    }
}
