using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    public static event Action<Vector3> onBoxMovement;

    public static void OnBoxMovement(Vector3 playerPosition)
    {
        onBoxMovement?.Invoke(playerPosition);
    }
}
