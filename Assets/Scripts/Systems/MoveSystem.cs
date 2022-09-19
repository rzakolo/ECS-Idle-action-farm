using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed class MoveSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private EcsFilter<DirectionComponent, MovableComponent, ModelComponent> moveFilter = null;
    public void Run()
    {
        foreach (var i in moveFilter)
        {
            ref var directionComponent = ref moveFilter.Get1(i);
            ref var movableComponent = ref moveFilter.Get2(i);
            ref var modelComponent = ref moveFilter.Get3(i);
            ref var characterController = ref movableComponent.CharacterController;
            ref var playerTransform = ref modelComponent.ModelTransform;
            ref var direction = ref directionComponent.Direction;
            ref var speed = ref movableComponent.Speed;
            ref var velocity = ref movableComponent.Velocity;
            ref var gravity = ref movableComponent.Gravity;
            var move = speed * direction * Time.deltaTime;
            if (!characterController.isGrounded)
            {
                move.y -= gravity * Time.deltaTime;
            }
            characterController.Move(move);
            velocity = characterController.velocity;
        }

    }
}
