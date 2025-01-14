using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1EasyEcs.Scripts.Custom;
using Exerussus.EasyEcsModules.BasicData;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECS.Modules.Exerussus.Movement
{
    public class MovementPooler : IGroupPooler
    {
        public virtual void Initialize(EcsWorld world)
        {
            Position = new PoolerModule<MovementData.Position>(world);
            Speed = new PoolerModule<MovementData.Speed>(world);
            Direction = new PoolerModule<MovementData.Direction>(world);
        }

        public PoolerModule<MovementData.Position> Position {get; private set; }
        public PoolerModule<MovementData.Speed> Speed {get; private set; }
        public PoolerModule<MovementData.Direction> Direction {get; private set; }

        public Vector3 GetPosition(int entity)
        {
            ref var positionData = ref Position.Get(entity);
            return positionData.Value;
        }
        
        public bool TryGetPosition(int entity, out Vector3 position)
        {
            if (!Position.Has(entity))
            {
                position = default;
                return false;
            }
            ref var positionData = ref Position.Get(entity);
            position = positionData.Value;
            return true;
        }
    }
}