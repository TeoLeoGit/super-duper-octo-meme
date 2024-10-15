using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.Burst.CompilerServices;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int _moveUnit = 8;
    [SerializeField] float _moveTime = 0.4f;
    private Vector3 _targetPosition;
    private bool _isMoving = false;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] Animator _animator;


    void Update()
    {
        if (_isMoving) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _targetPosition = transform.position + Vector3.left * _moveUnit;
            transform.localScale = Vector3.one + Vector3.left * 2;
            _animator.SetBool("right", true);
            _animator.SetBool("up", false);
            _animator.SetBool("down", false);
            _animator.SetBool("idle", false);

            MoveObjectWithTween();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _targetPosition = transform.position + Vector3.right * _moveUnit;
            transform.localScale = Vector3.one;
            _animator.SetBool("right", true);
            _animator.SetBool("up", false);
            _animator.SetBool("down", false);
            _animator.SetBool("idle", false);

            MoveObjectWithTween();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _targetPosition = transform.position + Vector3.up * _moveUnit;
            _animator.SetBool("up", true);
            _animator.SetBool("right", false);
            _animator.SetBool("down", false);
            _animator.SetBool("idle", false);

            MoveObjectWithTween();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _targetPosition = transform.position + Vector3.down * _moveUnit;
            _animator.SetBool("down", true);
            _animator.SetBool("right", false);
            _animator.SetBool("up", false);
            _animator.SetBool("idle", false);

            MoveObjectWithTween();
        }
    }

    void MoveObjectWithTween()
    {
        var ray = Physics2D.Raycast(transform.position, _targetPosition - transform.position, _moveUnit, _layerMask);
        if (ray.collider != null)
        {
            if (ray.collider.gameObject.TryGetComponent<Box>(out Box box)) 
            {
                if (box.CanMove(_targetPosition - transform.position))
                {
                    _isMoving = true;
                    transform.DOMove(_targetPosition, _moveTime).SetEase(Ease.OutQuad).OnComplete(() =>
                    {
                        _isMoving = false;
                        _animator.SetBool("down", false);
                        _animator.SetBool("right", false);
                        _animator.SetBool("up", false);
                        _animator.SetBool("idle", true);
                    });
                    GameController.OnPlayAudio(SoundType.Walking);
                }
            }
        } 
        else
        {
            _isMoving = true;
            transform.DOMove(_targetPosition, _moveTime).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                _isMoving = false;
                _animator.SetBool("down", false);
                _animator.SetBool("right", false);
                _animator.SetBool("up", false);
                _animator.SetBool("idle", true);
            });
        }
    }
}
