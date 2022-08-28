using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;
using Leopotam.Ecs.Ui.Systems;
using TMPro;
using UnityEngine.UI;

public class GameStartup : MonoBehaviour
{
    [SerializeField] private EcsUiEmitter _uiEmitter;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private GameData _gameData;
    [SerializeField] private PrefabFactory _prefabFactory;
    private EcsWorld _world;
    private EcsSystems _systems;


    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
#endif
        _systems.ConvertScene();
        AddSystems();

        _systems.Init();
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
    }

    private void Update()
    {
        _systems.Run();
    }

    private void AddSystems()
    {

        _systems.
            Add(new PlayerInputSystem()).
            Add(new MoveSystem()).
            Add(new PlayerAnimationSystem()).
            Add(new RotationSystem()).
            //Add(new StashSystem()).
            Add(new DistanceCheckSystem()).
            Add(new PrepareItemSystem()).
            Add(new TakingItemSystem()).
            Add(new UISystem()).
            Add(new GrowSystem()).
            Add(new SpawnSystem()).
            Add(new MoneySystem()).
            Add(new GravitationSystem()).
            OneFrame<ReadyToSpawnEvent>().
            OneFrame<SellEvent>().
            OneFrame<BrickSpawnEvent>().
            InjectUi(_uiEmitter).
            Inject(_joystick).
            Inject(_gameData).
            Inject(_prefabFactory);

    }


    private void OnDestroy()
    {
        if (_systems == null) return;

        _systems.Destroy();
        _systems = null;
        _world.Destroy();
        _world = null;
    }
}
