using UnityEngine;

namespace Character
{
    //юнити не поддерживает C# 10 с возможностью в структуре
    //создания конструктора без параметров, потому здесь класс
    public sealed class Step 
    {
        public readonly float Speed;
        public readonly Vector3 Direction;
        public Color? ChangedColor;

        public Step(float speed, Vector3 direction)
        {
            Speed = speed;
            Direction = direction;
        }
    }
}