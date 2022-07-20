using Leopotam.Ecs;
using UnityEngine;
sealed class RotationSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private EcsFilter<DirectionComponent, ModelComponent> moveFilter = null;

    public void Run()
    {
        foreach (var i in moveFilter)
        {
            ref var directionComponent = ref moveFilter.Get1(i);
            ref var transformComponent = ref moveFilter.Get2(i);
            ref var transform = ref transformComponent.ModelTransform;
            ref var direction = ref directionComponent.Direction;

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), 0.2f);
            }

        }
    }
}
