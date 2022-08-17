using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class SliceSystem : IEcsInitSystem
    {
        // auto-injected fields.
        private readonly EcsWorld _world = null;
        private EcsFilter<ReadyToSliceTag> _filter;

        public void Init()
        {
            foreach (var i in _filter)
            {

            }
        }
    }
}