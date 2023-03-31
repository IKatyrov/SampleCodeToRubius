using System.Collections.Generic;
using Character;
using UnityEngine;

namespace Abilities
{
    public sealed class AbilityFactory : MonoBehaviour
    {
        private IAbility<ICharacter>[] _abilities;

        public IReadOnlyList<IAbility<ICharacter>> Abilities => _abilities;

        private void Start()
        {
            _abilities = GetComponentsInChildren<IAbility<ICharacter>>();
        }
    }
}