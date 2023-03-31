using System.Collections.Generic;
using UnityEngine;

namespace Character.Player
{
    public sealed class PlayerMove : MonoBehaviour, IMovable
    {
        private const float Delay = 1f;
        
        private float _timeToChangeDirection;
        
        public float Speed { get; private set; }
        public Vector3 Direction { get; private set; }
        public Queue<Step> Steps { get; } = new Queue<Step>();
        public Step CurrentStep { get; private set; }

        public void Move()
        {
            CalculateDirection();
            transform.position += Direction * Speed * Time.deltaTime;
        }
        
        private void CalculateDirection()
        {
            _timeToChangeDirection -= Time.deltaTime;

            if (_timeToChangeDirection > 0)
            {
                return;
            }

            Direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            Speed = Random.Range(1f, 5f);

            CurrentStep = new Step(Speed, Direction);
            Steps.Enqueue(CurrentStep);

            _timeToChangeDirection = Delay;
        }
        
    }
}