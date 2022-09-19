using DG.Tweening;
using UnityEngine;

public class TweenMove
{
    public bool IsPlaying;
    public bool IsComplete;

    private Transform _start;
    private Transform _end;
    public void Init(ref Transform startTransform, ref Transform endTransform, float takingTime)
    {
        IsPlaying = true;
        _start = startTransform;
        _end = endTransform;
        var tween = _start.DOJump(_end.position, 3, 1, takingTime);
        //Debug.Log("Start position: " + _start.position + "\nEnd position: " + _end.position + "\n Object: " + _start.gameObject.name);
        tween.OnComplete(() => IsComplete = true);
    }
}
