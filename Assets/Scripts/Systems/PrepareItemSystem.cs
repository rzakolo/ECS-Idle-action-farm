using Leopotam.Ecs;
using UnityEngine;

public class PrepareItemSystem : IEcsRunSystem
{

    private readonly EcsFilter<TakeableComponent, ModelComponent>.Exclude<TakingEvent> _itemFilter = null;
    private readonly EcsFilter<StashComponent, PlayerTag> _stash = null;

    public void Run()
    {
        foreach (var idx in _stash)
        {
            ref var stashComponent = ref _stash.Get1(idx);
            ref var emptySlot = ref stashComponent.emptySlotIndex;


            foreach (var i in _itemFilter)
            {
                ref var takeableItemComponent = ref _itemFilter.Get1(i);
                if (takeableItemComponent.Takeable)
                {
                    ref var itemModelComponent = ref _itemFilter.Get2(i);
                    takeableItemComponent.StartTransform = itemModelComponent.ModelTransform;
                    ref var entity = ref _itemFilter.GetEntity(i);
                    if (emptySlot < stashComponent.stash.Length)
                    {
                        takeableItemComponent.EndTransform = stashComponent.stash[emptySlot].transform;
                        entity.Get<TakingEvent>();
                    }
                }
            }
        }
    }
}
