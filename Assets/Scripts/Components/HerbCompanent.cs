using System;
using UnityEngine;
using Leopotam.Ecs;

[Serializable]
public struct HerbCompanent
{
    public Transform Position;
    public bool IsPlanted;
    public EcsEntity HerbType;
    public GameObject View;
    public float GrowTime;
}
