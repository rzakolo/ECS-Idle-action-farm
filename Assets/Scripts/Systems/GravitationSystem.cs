using Leopotam.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GravitationSystem : IEcsRunSystem
{
    private EcsFilter<RigidbodyComponent> rigidbodyFilter = null;
    public void Run()
    {
        foreach (var i in rigidbodyFilter)
        {
            ref var rigidbodyComponent = ref rigidbodyFilter.Get1(i);
            ref var rigidbody = ref rigidbodyComponent.rigidbody;

            rigidbody.AddForce(Vector3.down);
        }
    }
}

