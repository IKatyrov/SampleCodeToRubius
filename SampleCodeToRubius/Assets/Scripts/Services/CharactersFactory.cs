using System.Collections.Generic;
using Character;
using Character.Player;
using Character.Shadow;
using Zenject;

namespace Services
{
    public sealed class CharactersFactory : IInitializable, ICharactersFactory
    {
        private readonly Dictionary<System.Type, ICharacter> _characters;
        
        [Inject] private readonly IResourceLoader _resourceLoader;
        [Inject] private readonly ICharactersProvider _charactersProvider;
        [Inject] private readonly ILogger _logger;
        [Inject] private readonly DiContainer _diContainer;

        public CharactersFactory()
        {
            _characters = new Dictionary<System.Type, ICharacter>();
        }

        public void Initialize()
        {
            _characters.Add(typeof(PlayerCharacter), _resourceLoader.LoadPlayerCharacter());
            _characters.Add(typeof(ShadowCharacter), _resourceLoader.LoadShadowCharacter());
        }

        public TCharacter Create<TCharacter>() 
            where TCharacter : UnityEngine.Object, ICharacter
        {
            TCharacter asset = _characters[typeof(TCharacter)] as TCharacter;

            TCharacter createdCharacter = _diContainer.InstantiatePrefabForComponent<TCharacter>
            (
                asset,
                parentTransform: null
            );
            
            _charactersProvider.AddCharacter(createdCharacter);

            _logger.PrintLog
            (
                createdCharacter is PlayerCharacter ? "Создан игрок" : "Создана тень"
            );

            return createdCharacter;
        }
        
        public TCharacter Create<TCharacter>(UnityEngine.Vector3 position) 
            where TCharacter : UnityEngine.Object, ICharacter
        {
            TCharacter asset = _characters[typeof(TCharacter)] as TCharacter;

            TCharacter createdCharacter = _diContainer.InstantiatePrefabForComponent<TCharacter>
            (
                asset,
                position,
                UnityEngine.Quaternion.identity,
                parentTransform: null
            );
            
            _charactersProvider.AddCharacter(createdCharacter);

            _logger.PrintLog
            (
                createdCharacter is PlayerCharacter
                    ? "Создан игрок"
                    : "Создана тень"
            );

            return createdCharacter;
        } 
        
        public TCharacter Create<TCharacter>(UnityEngine.Vector3 position, UnityEngine.Quaternion rotation) 
            where TCharacter : UnityEngine.Object, ICharacter
        {
            TCharacter asset = _characters[typeof(TCharacter)] as TCharacter;

            TCharacter createdCharacter = _diContainer.InstantiatePrefabForComponent<TCharacter>
            (
                asset,
                position,
                rotation,
                parentTransform: null
            );
            
            _charactersProvider.AddCharacter(createdCharacter);

            _logger.PrintLog
            (
                createdCharacter is PlayerCharacter
                    ? "Создан игрок"
                    : "Создана тень"
            );

            return createdCharacter;
        }
    }
}