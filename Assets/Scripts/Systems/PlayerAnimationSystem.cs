using Leopotam.Ecs;
using Zenject;
using UnityEngine;
using System;

internal class PlayerAnimationSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private EcsFilter<MovableComponent, AnimatorComponent> _filter = null;
    private int hash = Animator.StringToHash("Speed");
    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var playerAnimation = ref _filter.Get2(i);
            ref var velocity = ref _filter.Get1(i);
            playerAnimation.Animator.SetFloat(hash, velocity.Velocity.magnitude);
        }

    }
}

