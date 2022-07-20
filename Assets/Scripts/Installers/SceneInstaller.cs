using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private FloatingJoystick joystick;

    public override void InstallBindings()
    {
        Container.Bind<FloatingJoystick>().FromInstance(joystick).AsSingle();
    }
}
