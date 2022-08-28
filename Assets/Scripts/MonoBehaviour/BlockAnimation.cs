using UnityEngine;
using DG.Tweening;

public class BlockAnimation : MonoBehaviour
{
    private Vector3 _baseScale;
    private Sequence _sequence;
    private Sequence _sequenceLoop;
    void Start()
    {
        _sequence = DOTween.Sequence();
        _sequenceLoop = DOTween.Sequence();
        _baseScale = transform.localScale;
        transform.localScale = Vector3.zero;
        _sequence.Append(transform.DOScale(_baseScale, 1));
        _sequenceLoop.Append(transform.DORotate(new Vector3(0, 270, 0), 1));
        _sequenceLoop.Join(transform.DOMoveY(1, 1));
        _sequenceLoop.SetLoops(-1, LoopType.Yoyo);
    }
    private void OnDestroy()
    {
        _sequenceLoop.Kill();
    }
}
