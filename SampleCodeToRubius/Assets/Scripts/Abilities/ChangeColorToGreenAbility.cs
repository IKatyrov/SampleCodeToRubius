using Character;
using UnityEngine;

namespace Abilities
{
    public sealed class ChangeColorToGreenAbility : MonoBehaviour, IAbility<ICharacter>
    {
        [SerializeField] private float _targetSpeed;
        
        private void OnValidate()
        {
            if (_targetSpeed <= 0)
            {
                _targetSpeed = 0.1f;
            }
        }

        public bool CheckCondition(ICharacter owner)
        {
            return owner.Movable.Speed > _targetSpeed;
        }

        public void TriggerAbility(ICharacter owner)
        {
            owner.ChangeToGreenColor();
        }
    }
}