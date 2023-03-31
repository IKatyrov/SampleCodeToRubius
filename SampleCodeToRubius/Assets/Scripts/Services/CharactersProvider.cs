using System.Collections.Generic;
using Character;
using Character.Player;

namespace Services
{
    public sealed class CharactersProvider : ICharactersProvider
    {
        private const int CapacityCharactersList = 32;
        
        private readonly List<ICharacter> _characters;
        private PlayerCharacter _playerCharacter;

        public IReadOnlyList<ICharacter> Characters => _characters;

        public PlayerCharacter PlayerCharacter
        {
            get => _playerCharacter;
            set
            {
                if (_playerCharacter != null)
                    return;
                _playerCharacter = value;
            }
        }

        public CharactersProvider()
        {
            _characters = new List<ICharacter>(CapacityCharactersList);
        }

        public void AddCharacter(ICharacter character)
        {
            _characters.Add(character);
        }

        public void RemoveCharacter(ICharacter character)
        {
            _characters.Remove(character);
        }

    }
}