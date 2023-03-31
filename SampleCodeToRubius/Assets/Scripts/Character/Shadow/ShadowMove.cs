using System.Collections.Generic;
using UnityEngine;

namespace Character.Shadow
{
    public sealed class ShadowMove : MonoBehaviour, IMovable
    {
        private const float Delay = 1f;
        
        private float _timeToChangeDirection;
        
        public float Speed { get; private set; }
        public Vector3 Direction { get; private set; }
        public Queue<Step> Steps { get; } = new Queue<Step>();
        public Step CurrentStep { get; private set; }
        
        
        public void Move()
        {
            ChangeStep();
            CalculateDirection();
            transform.position += Direction * Speed * Time.deltaTime;
        }
        
        private void CalculateDirection()
        {
            if (CurrentStep == null)
            {
                Direction = Vector3.zero;
                Speed = 0;
                return;
            }
            
            Direction = CurrentStep.Direction;
            Speed = CurrentStep.Speed;
        }

        private void ChangeStep()
        {
            _timeToChangeDirection -= Time.deltaTime;

            if (_timeToChangeDirection > 0)
            {
                return;
            }

            if (Steps.Count > 0)
            {
                CurrentStep = Steps.Dequeue();
                _timeToChangeDirection = Delay;
            }
            else
            {
                CurrentStep = null;
            }

        }

    }
}