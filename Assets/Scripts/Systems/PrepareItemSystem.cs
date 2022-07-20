using Leopotam.Ecs;
using UnityEngine;

public class PrepareItemSystem : IEcsRunSystem
{

    private readonly EcsFilter<TakeableItemComponent, ModelComponent>.Exclude<TakingEvent> _itemFilter = null;
    public void Run()
    {
        if (_itemFilter == null) return;
        foreach (var i in _itemFilter)
        {
            ref var takeableItemComponent = ref _itemFilter.Get1(i);
            if (takeableItemComponent.Takeable)
            {
                ref var itemModelComponent = ref _itemFilter.Get2(i);
                takeableItemComponent.StartPosition = itemModelComponent.ModelTransform.position;
                takeableItemComponent.StartRotation = itemModelComponent.ModelTransform.rotation;
                ref var entity = ref _itemFilter.GetEntity(i);
                entity.Get<TakingEvent>();
            }
        }
    }
}
