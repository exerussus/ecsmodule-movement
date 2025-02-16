using System;
using ECS.Modules.Exerussus.Movement.Systems;
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus._1EasyEcs.Scripts.Custom;
using Exerussus._1Extensions.SmallFeatures;
using Exerussus.EasyEcsModules.BasicData;
using Leopotam.EcsLite;

namespace ECS.Modules.Exerussus.Movement
{
    public class MovementGroup : EcsGroup<MovementPooler>
    {
        public MovementSettings Settings;

        protected override void SetUpdateSystems(IEcsSystems updateSystems)
        {
            if (Settings.Update != UpdateType.Update) return;

            switch (Settings.MovementMode)
            {
                case MovementMode.Move:
                    updateSystems.Add(new MovementSystem { UpdateDelay = Settings.SystemUpdateDelay });
                    break;
                case MovementMode.TransformRelay:
                    updateSystems.Add(new RelaySystem { UpdateDelay = Settings.SystemUpdateDelay });
                    break;
            }
        }

        protected override void SetLateUpdateSystems(IEcsSystems lateUpdateSystems)
        {
            if (Settings.Update != UpdateType.LateUpdate) return;
            
            switch (Settings.MovementMode)
            {
                case MovementMode.Move:
                    lateUpdateSystems.Add(new MovementSystem { UpdateDelay = Settings.SystemUpdateDelay });
                    break;
                case MovementMode.TransformRelay:
                    lateUpdateSystems.Add(new RelaySystem { UpdateDelay = Settings.SystemUpdateDelay });
                    break;
            }
        }

        protected override void SetFixedUpdateSystems(IEcsSystems fixedUpdateSystems)
        {
            if (Settings.Update != UpdateType.FixedUpdate) return;
            
            switch (Settings.MovementMode)
            {
                case MovementMode.Move:
                    fixedUpdateSystems.Add(new MovementSystem { UpdateDelay = Settings.SystemUpdateDelay });
                    break;
                case MovementMode.TransformRelay:
                    fixedUpdateSystems.Add(new RelaySystem { UpdateDelay = Settings.SystemUpdateDelay });
                    break;
            }
        }

        protected override void SetSharingData(EcsWorld world, GameShare gameShare)
        {
#if UNITY_EDITOR
            if (Settings == null) throw new Exception("EASY ECS | MOVEMENT GROUP | SETTINGS NOT ASSIGNED.");
            if (Settings.SystemUpdateDelay > Settings.EntityUpdateDelay) throw new Exception("EASY ECS | MOVEMENT GROUP | SystemUpdateDelay more then EntityUpdateDelay.");
#endif
            gameShare.AddSharedObject(Settings);
        }

        public MovementGroup SetSettings(MovementSettings settings)
        {
            Settings = settings;
            return this;
        }
    }
}