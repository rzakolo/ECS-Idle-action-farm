using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockAnimation : MonoBehaviour
{
    private Vector3 _baseScale;
    Sequence sequence;
    Sequence sequenceLoop;
    void Start()
    {
        sequence = DOTween.Sequence();
        sequenceLoop = DOTween.Sequence();
        _baseScale = transform.localScale;
        transform.localScale = Vector3.zero;
        sequence.Append(transform.DOScale(_baseScale, 1));
        sequenceLoop.Append(transform.DORotate(new Vector3(0, 270, 0), 1));
        sequenceLoop.Join(transform.DOMoveY(1, 1));
        sequenceLoop.SetLoops(-1, LoopType.Yoyo);
    }
    private void OnDestroy()
    {
        sequenceLoop.Kill();
    }
}
