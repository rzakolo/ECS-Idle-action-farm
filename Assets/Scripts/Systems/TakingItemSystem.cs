using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using EzySlice;
internal class TakingItemSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<TakeableComponent, ModelComponent, ColorComponent, TakingEvent> _item = null;
    private readonly EcsFilter<StashCompanent, PlayerTag> _stash = null;
    private readonly GameData _gameData = null;
    private float _takingTime;
    private TweenMove _tween;

    public void Init()
    {
        _takingTime = _gameData.TakingTime;
        _tween = new TweenMove();
    }

    public void Run()
    {
        if (!_item.IsEmpty())
            foreach (var i in _item)
            {
                ref var takeableCompanent = ref _item.Get1(i);
                ref var startTransform = ref takeableCompanent.StartTransform;
                ref var endTransform = ref takeableCompanent.EndTransform;
                ref var entity = ref _item.GetEntity(i);

                if (_tween.IsPlaying)
                {
                    _tween.UptadeEndPositionAndRotation(endTransform.position, endTransform.rotation);
                }
                else
                {
                    _tween.Move(ref startTransform, ref endTransform, _takingTime);
                }
                if (_tween.IsComplete)
                {

                    foreach (var idx in _stash)
                    {
                        ref var stashComponent = ref _stash.Get1(idx);
                        stashComponent.stash[stashComponent.emptySlotIndex].SetActive(true);
                        stashComponent.emptySlotIndex++;
                    }
                    var takeableGameObject = _item.Get2(i).ModelTransform.gameObject;
                    GameObject.Destroy(takeableGameObject);
                    entity.Destroy();
                    _tween = new TweenMove();
                }
            }
    }
}

