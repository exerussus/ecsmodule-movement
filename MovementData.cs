using Exerussus._1EasyEcs.Scripts.Core;
using UnityEngine;

namespace ECS.Modules.Exerussus.Movement
{
    public static class MovementData
    {
        /// <summary> В какой текущей точке находится сущность </summary>
        public struct Position : IEcsComponent { public Vector3 Value; }
        /// <summary> В какую сторону двигается сущность </summary>
        public struct Direction : IEcsComponent { public Vector3 Value; }
        /// <summary> С какой скорость двигается сущность </summary>
        public struct Speed : IEcsComponent { public float Value; }
    }
}