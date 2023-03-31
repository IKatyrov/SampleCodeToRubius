using Character;
using UnityEngine;

namespace Abilities
{
    public sealed class ChangeColorAbility : MonoBehaviour, IAbility<ICharacter>
    {
        [SerializeField] private float _targetDistance;

        private void OnValidate()
        {
            if (_targetDistance <= 0)
            {
                _targetDistance = 0.1f;
            }
        }
        
        public bool CheckCondition(ICharacter owner)
        {
            return owner.DistanceTracker.DistanceTraveled >= _targetDistance;
        }

        public void TriggerAbility(ICharacter owner)
        {
            owner.ChangeToRandomColor();
            owner.DistanceTracker.DistanceTraveled = 0f;
            
        }
    }
}