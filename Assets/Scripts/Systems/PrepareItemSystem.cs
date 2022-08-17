using Leopotam.Ecs;
using UnityEngine;

public class PrepareItemSystem : IEcsRunSystem
{

    private readonly EcsFilter<TakeableComponent, ModelComponent>.Exclude<TakingEvent> _itemFilter = null;
    private readonly EcsFilter<StashCompanent, PlayerTag> _stash = null;
    public void Run()
    {
        if (!_itemFilter.IsEmpty() && !_stash.IsEmpty())
        {
            foreach (var i in _itemFilter)
            {
                ref var takeableItemComponent = ref _itemFilter.Get1(i);
                if (takeableItemComponent.Takeable)
                {
                    ref var itemModelComponent = ref _itemFilter.Get2(i);
                    takeableItemComponent.StartTransform = itemModelComponent.ModelTransform;
                    ref var entity = ref _itemFilter.GetEntity(i);
                    entity.Get<TakingEvent>();
                }
                foreach (var idx in _stash)
                {
                    ref var stashCompanentComponent = ref _stash.Get1(idx);
                    ref var emptySlot = ref stashCompanentComponent.emptySlotIndex;
                    takeableItemComponent.EndTransform = stashCompanentComponent.stash[emptySlot].transform;
                }
            }
        }
    }
}
