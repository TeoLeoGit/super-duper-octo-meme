using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    public static event Action<Vector3> onBoxMovement;
    public static event Action<int> onUpdateTargetCount;
    public static event Action<SoundType> onPlayAudio;
    public static event Action<SoundType> onStopAudio;

    public static void OnBoxMovement(Vector3 playerPosition)
    {
        onBoxMovement?.Invoke(playerPosition);
    }

    public static void OnUpdateTargetCount(int finTargetCount)
    {
        onUpdateTargetCount?.Invoke(finTargetCount);
    }

    public static void OnPlayAudio(SoundType type)
    {
        onPlayAudio?.Invoke(type);
    }

    public static void OnStopAudio(SoundType type)
    {
        onStopAudio?.Invoke(type);
    }
}
