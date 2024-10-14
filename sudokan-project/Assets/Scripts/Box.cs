using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;
    private Vector3 gizmos;
    public bool CanMove(Vector3 direction)
    {
        var hits = Physics2D.RaycastAll(transform.position, direction, 16, _layerMask);
        gizmos = transform.position + direction;

        if (hits.Length == 0 || (hits.Length == 1 && hits[0].collider.gameObject == this.gameObject))
        {
            transform.DOMove(transform.position + direction, 0.4f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                GameController.OnBoxMovement(transform.position);
            });
            return true;
        }
        else
            return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, gizmos);
    }
}
