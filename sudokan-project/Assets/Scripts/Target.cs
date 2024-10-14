using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void Awake()
    {
        GameController.onBoxMovement += CheckFinishTarget;
    }

    private void OnDestroy()
    {
        GameController.onBoxMovement -= CheckFinishTarget;
    }

    private void CheckFinishTarget(Vector3 boxPos)
    {
        if ((Vector2)boxPos == (Vector2)transform.position)
        {
            Debug.Log("yes sir!");
        }
    }
}
