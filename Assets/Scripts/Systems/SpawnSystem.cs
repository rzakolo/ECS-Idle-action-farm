using Leopotam.Ecs;
using UnityEngine;

sealed class SpawnSystem : IEcsRunSystem
{
    readonly private EcsWorld _world = null;
    readonly private PrefabFactory _prefabFactory;
    readonly private GameData _gameData;
    readonly private EcsFilter<HerbComponent, ReadyToSpawnEvent> _herbFilter = null;
    readonly private EcsFilter<ModelComponent, BrickSpawnEvent, ColorComponent> _brickFilter = null;
    public void Run()
    {
        if (!_herbFilter.IsEmpty())
        {
            foreach (var i in _herbFilter)
            {
                ref var herbCompanent = ref _herbFilter.Get1(i);
                var goToSpawn = herbCompanent.View;
                var herbTransform = herbCompanent.Position;
                ref var entity = ref _herbFilter.GetEntity(i);
                _prefabFactory.Spawn(goToSpawn, herbTransform.position, Quaternion.identity, null, entity);
                entity.Get<BlockHole>();
            }
        }
        if (!_brickFilter.IsEmpty())
        {
            foreach (var i in _brickFilter)
            {
                ref var modelCompanent = ref _brickFilter.Get1(i);
                ref var modelTransform = ref modelCompanent.ModelTransform;
                ref var colorComponent = ref _brickFilter.Get3(i);
                var renderer = _gameData.BrickPrefab.GetComponent<Renderer>();
                var propertyId = Shader.PropertyToID("_BaseMap");
                renderer.sharedMaterial.SetColor(propertyId, colorComponent.MaterialColor);
                _prefabFactory.Spawn(_gameData.BrickPrefab, modelTransform.position, Quaternion.identity, null, EcsEntity.Null);
                _brickFilter.GetEntity(i).Destroy();
            }
        }
    }
}
