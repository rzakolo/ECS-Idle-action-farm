using UnityEngine;
using Leopotam.Ecs;

public class MoneySystem : IEcsInitSystem
{
    EcsFilter<MoneyComponent> _moneyFilter;
    public void Init()
    {

    }
}
