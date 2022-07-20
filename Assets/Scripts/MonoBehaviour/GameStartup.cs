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
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private GameData gameData;
    private EcsWorld world;
    private EcsSystems systems;


    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(world);
#endif
        systems.ConvertScene();
        AddSystems();

        systems.Init();
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(systems);
#endif
    }

    private void Update()
    {
        systems.Run();
    }

    private void AddSystems()
    {

        systems.
            Add(new PlayerInputSystem()).
            Add(new MoveSystem()).
            Add(new PlayerAnimationSystem()).
            Add(new RotationSystem()).
            //Add(new StashSystem()).
            Add(new DistanceCheckSystem()).
            Add(new TakingItemSystem()).
            Add(new PrepareItemSystem()).
            Add(new UISystem()).
            InjectUi(_uiEmitter).
            Inject(joystick).
            Inject(gameData);

    }


    private void OnDestroy()
    {
        if (systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
}
