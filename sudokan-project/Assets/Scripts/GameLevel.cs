using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] int targetCount;

    private int currentFinTarget = 0;

    private void Awake()
    {
        GameController.onUpdateTargetCount += OnTargetCountUpdate;
    }

    private void OnDestroy()
    {
        GameController.onUpdateTargetCount -= OnTargetCountUpdate;
    }

    private void OnTargetCountUpdate(int finTargetCount)
    {
        currentFinTarget += finTargetCount;
        if (targetCount == currentFinTarget)
        {
            //Call end game.
            Debug.Log("Fin!");
        }
    }
}
