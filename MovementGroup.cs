using ECS.Modules.Exerussus.Movement.Systems;
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1EasyEcs.Scripts.Custom;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Movement
{
    public class MovementGroup : EcsGroup<MovementPooler>
    {
        public MovementSettings Settings = new();

        protected override void SetInitSystems(IEcsSystems initSystems)
        {
            if (!Settings.HasMoveProcess) initSystems.Add(new MovementSystem());
        }

        protected override void SetUpdateSystems(IEcsSystems updateSystems)
        {
            if (Settings.HasMoveProcess && Settings.Update == UpdateType.Update) updateSystems.Add(new MovementSystem());
        }

        protected override void SetLateUpdateSystems(IEcsSystems lateUpdateSystems)
        {
            if (Settings.HasMoveProcess && Settings.Update == UpdateType.LateUpdate) lateUpdateSystems.Add(new MovementSystem());
        }

        protected override void SetFixedUpdateSystems(IEcsSystems fixedUpdateSystems)
        {
            if (Settings.HasMoveProcess && Settings.Update == UpdateType.FixedUpdate) fixedUpdateSystems.Add(new MovementSystem());
        }
        
        public MovementGroup SetUpdateType(UpdateType updateType)
        {
            Settings.Update = updateType;
            return this;
        }
        
        public MovementGroup SetMoveProcess(bool isEnabled)
        {
            Settings.HasMoveProcess = isEnabled;
            return this;
        }
    }
}