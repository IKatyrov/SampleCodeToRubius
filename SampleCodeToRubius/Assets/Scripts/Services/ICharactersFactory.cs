using Character;

namespace Services
{
    public interface ICharactersFactory
    {
        TCharacter Create<TCharacter>() 
            where TCharacter : UnityEngine.Object, ICharacter;

        TCharacter Create<TCharacter>(UnityEngine.Vector3 position) 
            where TCharacter : UnityEngine.Object, ICharacter;

        TCharacter Create<TCharacter>(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation) 
            where TCharacter : UnityEngine.Object, ICharacter;
    }
}