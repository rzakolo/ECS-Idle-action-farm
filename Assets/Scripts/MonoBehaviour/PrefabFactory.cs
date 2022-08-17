using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Voody.UniLeo;

public class PrefabFactory : MonoBehaviour
{
    private EcsWorld _world = null;
    private void Start()
    {
        _world = WorldHandler.GetWorld();
    }
    public void Spawn(GameObject gameObject, Vector3 position, Quaternion quaternion, Transform parentTransform, EcsEntity parentEntity)
    {
        var entity = _world.NewEntity();
        //ref var sliceComponent = ref entity.Get<ReadyToSliceTag>();
        ref var modelComponent = ref entity.Get<ModelComponent>();
        ref var parentCompanent = ref entity.Get<ParentCompanent>();

        modelComponent.ModelTransform = gameObject.transform;
        parentCompanent.ParentEntity = parentEntity;

        Instantiate(gameObject, position, quaternion, parentTransform);
    }
}
