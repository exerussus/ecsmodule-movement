using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1EasyEcs.Scripts.Custom;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Movement
{
    public class MovementPooler : IGroupPooler
    {
        public void Initialize(EcsWorld world)
        {
            Position = new PoolerModule<MovementData.Position>(world);
            Speed = new PoolerModule<MovementData.Speed>(world);
            Direction = new PoolerModule<MovementData.Direction>(world);
        }

        public PoolerModule<MovementData.Position> Position {get; private set; }
        public PoolerModule<MovementData.Speed> Speed {get; private set; }
        public PoolerModule<MovementData.Direction> Direction {get; private set; }
    }
}