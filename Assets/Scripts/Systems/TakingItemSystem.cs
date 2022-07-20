using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using EzySlice;
internal class TakingItemSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<TakeableItemComponent, ModelComponent, ColorComponent, TakingEvent> _item = null;
    private readonly EcsFilter<StashCompanent, PlayerTag> _stash = null;
    private readonly GameData _gameData = null;
    private bool _onSequenceStart;
    private float _takingTime;

    public void Init()
    {
        _takingTime = _gameData.TakingTime;
        DOTween.SetTweensCapacity(500, 500);
    }

    public void Run()
    {
        foreach (var i in _item)
        {
            ref var itemComponent = ref _item.Get1(i);
            var itemModel = _item.Get2(i).ModelTransform;
            var itemColor = _item.Get3(i).MaterialColor;

            foreach (var index in _stash)
            {
                ref var stashComponent = ref _stash.Get1(index);
                ref var itemsInStash = ref stashComponent.stash;
                ref var emptySlotIndex = ref stashComponent.emptySlotIndex;
                var item = stashComponent.stash[emptySlotIndex];

                var endPosition = itemsInStash[emptySlotIndex].transform.position;
                var endRotation = itemsInStash[emptySlotIndex].transform.rotation;

                var sequence = DOTween.Sequence();
                sequence.Append(itemModel.transform.DOMove(endPosition, _takingTime));
                sequence.Join(itemModel.transform.DORotateQuaternion(endRotation, _takingTime));
                _takingTime -= Time.deltaTime;

                if (!_onSequenceStart)
                {
                    _onSequenceStart = true;
                    sequence.onKill += () =>
                    {
                        ref var entity = ref _item.GetEntity(i);
                        item.SetActive(true);
                        item.gameObject.GetComponent<Renderer>().material.color = itemColor;
                        _takingTime = _gameData.TakingTime;
                        entity.Destroy();
                        GameObject.Destroy(itemModel.gameObject);
                        _item.Destroy();
                        _onSequenceStart = false;
                    };
                    emptySlotIndex++;
                }

            }
        }
    }
}

