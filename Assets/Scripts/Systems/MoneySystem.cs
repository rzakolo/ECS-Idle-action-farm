using UnityEngine;
using Leopotam.Ecs;

public class MoneySystem : IEcsRunSystem
{
    private readonly EcsFilter<MoneyComponent, StashCompanent> _filter;
    private readonly EcsFilter<SellEvent> _filter2;
    private readonly GameData _gameData;

    public void Run()
    {
        if (!_filter2.IsEmpty())
            foreach (var i in _filter)
            {
                ref var moneyComponent = ref _filter.Get1(i);
                ref var stashCompanentComponent = ref _filter.Get2(i);
                ref var money = ref moneyComponent.Money;
                ref var counter = ref stashCompanentComponent.emptySlotIndex;
                money += counter * _gameData.MoneyTakingAmount;
                counter = 0;
                foreach (var item in stashCompanentComponent.stash)
                {
                    item.SetActive(false);
                }
            }
    }
}
