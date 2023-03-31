using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public interface IMovable
    {
        float Speed { get; }
        Vector3 Direction { get; }
        Queue<Step> Steps { get; }
        Step CurrentStep { get; }
        void Move();
    }
}