using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Zenject;

sealed class PlayerInputSystem : IEcsRunSystem
{
    //public PlayerInputSystem(FloatingJoystick floatingJoystick)
    //{
    //    this.floatingJoystick = floatingJoystick;
    //}

    private FloatingJoystick floatingJoystick;
    private EcsWorld _world = null;
    private EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;
    private float moveX;
    private float moveZ;
    public void Run()
    {
        SetDirection();
        foreach (var i in directionFilter)
        {
            ref var directionComponent = ref directionFilter.Get2(i);
            ref var direction = ref directionComponent.Direction;


            direction.x = moveX;
            direction.z = moveZ;
        }
    }

    private void SetDirection()
    {
        moveX = floatingJoystick.Direction.x;
        moveZ = floatingJoystick.Direction.y;
    }
}
