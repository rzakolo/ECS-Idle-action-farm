using Leopotam.Ecs;
using UnityEngine;

internal class DistanceCheckSystem : IEcsRunSystem
{
    private readonly EcsFilter<TakeableItemComponent, ModelComponent> _item = null;
    private readonly EcsFilter<ModelComponent, PlayerTag> _player = null;
    private readonly GameData _gameData = null;

    public void Run()
    {
        foreach (var i in _item)
        {
            ref var itemModelComponent = ref _item.Get2(i);
            ref var takeableItemComponent = ref _item.Get1(i);
            var itemPosition = itemModelComponent.ModelTransform.position;
            foreach (var index in _player)
            {
                ref var playerModelComponent = ref _player.Get1(index);
                var playerPosition = playerModelComponent.ModelTransform.position;
                if (Vector3.Distance(itemPosition, playerPosition) <= _gameData.PickableDistance)
                {
                    takeableItemComponent.Takeable = true;
                }
            }
        }
    }
}

