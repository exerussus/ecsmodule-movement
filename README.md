Модуль для 1EasyEcs.   
Базовый модуль для передвижения точек в пространстве.   
Необходим для использования других модулей.   

```csharp
    public static class MovementData
    {
        /// <summary> В какой текущей точке находится сущность </summary>
        public struct Position : IEcsComponent { public Vector3 Value; }
        /// <summary> В какую сторону двигается сущность </summary>
        public struct Direction : IEcsComponent { public Vector3 Value; }
        /// <summary> С какой скорость двигается сущность </summary>
        public struct Speed : IEcsComponent { public float Value; }
    }
```

Зависимости:  
[Ecs-Lite](https://github.com/Leopotam/ecslite.git)  
[1EasyEcs](https://github.com/exerussus/1EasyEcs.git)   