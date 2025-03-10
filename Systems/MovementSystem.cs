using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus.EasyEcsModules.BasicData;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Modules.Exerussus.Movement.Systems
{
    public class MovementSystem : EasySystem<MovementPooler>
    {
        [InjectSharedObject] private MovementSettings _movementSettings;
        private EcsFilter _movingFilter;
        
        protected override void Initialize()
        {
            _movingFilter = World.Filter<MovementData.Position>().Inc<MovementData.Speed>().Inc<MovementData.Direction>().End();
        }

        protected override void Update()
        {
            foreach (var entity in _movingFilter)
            {
                ref var positionData = ref Pooler.Position.Get(entity);
                if (positionData.NextTimeUpdate > Time.time) continue;
                positionData.NextTimeUpdate = Time.time + _movementSettings.EntityUpdateDelay;
                
                ref var speedData = ref Pooler.Speed.Get(entity);
                ref var directionData = ref Pooler.Direction.Get(entity);
                
                positionData.PrevValue = positionData.Value;
                positionData.Value += directionData.Value * (speedData.Value * DeltaTime);
            }
        }
    }
}