using System.Collections.Generic;
using Character;
using Character.Player;

namespace Services
{
    public interface ICharactersProvider
    {
        IReadOnlyList<ICharacter> Characters { get; }
        PlayerCharacter PlayerCharacter { get; set; }
        void AddCharacter(ICharacter character);
        void RemoveCharacter(ICharacter character);
    }
}