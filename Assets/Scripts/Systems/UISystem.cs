using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class UISystem : IEcsRunSystem, IEcsInitSystem
{
    private EcsUiEmitter _ui = null;
    private EcsWorld _world = null;
    private EcsFilter<StashCompanent> _filter;
    private EcsFilter<MoneyComponent> _filter2;
    [EcsUiNamed("Stash")] private TextMeshProUGUI _stash;
    [EcsUiNamed("Money")] private TextMeshProUGUI _money;

    private int _stashIndex;
    private int _currentMoney;

    public void Init()
    {
        //Debug.Log(_ui == null);
        //var button = _ui.GetNamedObject("MyButton").GetComponent<Button>();
    }

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var emptySlot = ref _filter.Get1(i).emptySlotIndex;
            if (_stashIndex == emptySlot) return;
            _stashIndex = emptySlot;
            _stash.text = $"Stash: {_stashIndex}/40";
        }
        foreach (var i in _filter2)
        {
            ref var money = ref _filter2.Get1(i).Money;
            if (_currentMoney == money) return;
            _currentMoney = money;
            _money.text = $"Money: {money}";

        }
    }

}

