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
    [EcsUiNamed("Stash")] private TextMeshProUGUI _stash;

    private int _stashIndex;

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
            _stashIndex++;
            _stash.text = $"Stash: {_stashIndex}/40";
        }
    }
}

