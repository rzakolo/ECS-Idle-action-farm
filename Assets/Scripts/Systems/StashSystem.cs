using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Zenject;

public class StashSystem : IEcsRunSystem
{
    private readonly EcsFilter<StashCompanent> _filter = null;
    private int _currentIndex;
    private int _nextIndex;
    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var items = ref _filter.Get1(i).stash;
            _nextIndex = _filter.Get1(i).emptySlotIndex;
            if (_currentIndex != _nextIndex && _currentIndex < items.Length)
            {
                Test(items);
                _currentIndex = _nextIndex;
            }
        }
    }

    private void Test(GameObject[] items)
    {
        items[_currentIndex].SetActive(true);
        items[_currentIndex].gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
