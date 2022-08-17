using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMove
{
    public bool IsPlaying;
    public bool IsComplete;

    private Tweener _changePos;
    private Tweener _changeRot;
    private Sequence _jumpTween;
    private float _takingTime;
    private Transform _target;
    public void Move(ref Transform startTransform, ref Transform endTransform, float takingTime)
    {
        IsPlaying = true;
        _takingTime = takingTime;
        _target = startTransform;
        var endPosition = endTransform.position;
        var endRotation = endTransform.rotation;
        _changePos = _target.DOMove(endPosition, _takingTime);
        _jumpTween = _target.DOJump(new Vector3(startTransform.position.x, 4), 1, 1, 0.4f);
        _changeRot = _target.DORotateQuaternion(endRotation, _takingTime);
        _changePos.Play();
        _changeRot.Play();
    }
    public void UptadeEndPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        _changePos.ChangeEndValue(position, newDuration: 0.3f, true);
        _changeRot.ChangeEndValue(rotation, true);
        if (Vector3.Distance(_target.position, position) <= 0.1f)
            IsComplete = true;
        if (IsComplete)
        {
            _changePos.Kill();
            _changeRot.Kill();
        }
    }
}
