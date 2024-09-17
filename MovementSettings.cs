
using Exerussus._1EasyEcs.Scripts.Core;

namespace ECS.Modules.Exerussus.Movement
{
    public class MovementSettings
    {
        /// <summary> В каком апдейте производится работа. </summary>
        public UpdateType Update = UpdateType.FixedUpdate;
        /// <summary> Если false - не двигает позицию даже при имении Movement.Direction.
        /// Это значит, что другая система будет определять значения позиции. </summary>
        public bool HasMoveProcess = true;
    }
}