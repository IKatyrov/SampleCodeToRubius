using UnityEngine;

namespace Character
{
    public sealed class DistanceTracker : MonoBehaviour
    {
        private float _totalDistanceX;
        private float _totalDistanceZ;

        public float DistanceTraveled
        {
            get => _totalDistanceX + _totalDistanceZ;
            set
            {
                _totalDistanceX = 0;
                _totalDistanceZ = 0;
            }
        }

        public void CalculateDistance(Vector3 movementDirection, float movementSpeed)
        {
            float distanceX = movementDirection.x * movementSpeed * Time.deltaTime;
            float distanceZ = movementDirection.z * movementSpeed * Time.deltaTime;
            
            _totalDistanceX += Mathf.Abs(distanceX);
            _totalDistanceZ += Mathf.Abs(distanceZ);
        }
    }
}