using Leopotam.Ecs;
using UnityEngine;

sealed class GrowSystem : IEcsRunSystem, IEcsInitSystem
{
    readonly private EcsFilter<HerbCompanent>.Exclude<BlockHole> _filter = null;
    readonly private GameData _gameData;

    public void Init()
    {
        foreach (var i in _filter)
        {
            ref var timer = ref _filter.Get1(i).GrowTime;
            timer = _gameData.BaseGrowTime;
        }
    }

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var herbCompanent = ref _filter.Get1(i);
            if (!herbCompanent.IsPlanted)
                continue;
            ref var currentTime = ref herbCompanent.GrowTime;
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                _filter.GetEntity(i).Get<ReadyToSpawnEvent>();
                herbCompanent.GrowTime = _gameData.BaseGrowTime;
            }
        }
    }
}
