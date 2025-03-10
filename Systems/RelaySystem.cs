
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus.EasyEcsModules.BasicData;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Modules.Exerussus.Movement.Systems
{
    public class RelaySystem : EasySystem<MovementPooler>
    {
        [InjectSharedObject] private MovementSettings _movementSettings;
        private EcsFilter _relayFilter;
        
        protected override void Initialize()
        {
            _relayFilter = World.Filter<MovementData.Position>().Inc<UnityData.Transform>().End();
        }

        protected override void Update()
        {
            foreach (var entity in _relayFilter)
            {
                ref var positionData = ref Pooler.Position.Get(entity);
                if (positionData.NextTimeUpdate > Time.time) continue;
                positionData.NextTimeUpdate = Time.time + _movementSettings.EntityUpdateDelay;
                
                ref var transformData = ref Pooler.Transform.Get(entity);
                
                positionData.PrevValue = positionData.Value;
                positionData.Value = transformData.Value.position;
            }
        }
    }
}