
using Exerussus._1EasyEcs.Scripts.Core;
using Exerussus.EasyEcsModules.BasicData;

namespace ECS.Modules.Exerussus.Movement
{
    public class MovementSettings
    {
        public MovementSettings(MovementMode movementMode)
        {
            MovementMode = movementMode;
        }

        /// <summary> Определяет работу MovementGroup. </summary>
        public MovementMode MovementMode;
        /// <summary> В каком апдейте производится работа. </summary>
        public UpdateType Update = UpdateType.FixedUpdate;

        /// <summary> Насколько часто будет обновляться, либо двигаться сущность.
        /// Для корректной работы, поле
        /// <see cref="ECS.Modules.Exerussus.Movement.MovementSettings.EntityUpdateDelay"/>
        /// должно быть больше, чем
        /// <see cref="ECS.Modules.Exerussus.Movement.MovementSettings.SystemUpdateDelay"/>.
        /// Работает на любой MovementMode, кроме None. </summary>
        public float EntityUpdateDelay;
        
        /// <summary> Насколько часто будет обновляться система.
        /// Для корректной работы, поле
        /// <see cref="ECS.Modules.Exerussus.Movement.MovementSettings.SystemUpdateDelay"/>
        /// должно быть меньше, чем
        /// <see cref="ECS.Modules.Exerussus.Movement.MovementSettings.EntityUpdateDelay"/>.
        /// Работает на любой MovementMode, кроме None. </summary>
        public float SystemUpdateDelay;
    }
}