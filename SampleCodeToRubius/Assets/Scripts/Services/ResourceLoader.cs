using System.Collections.Generic;
using Character.Player;
using Character.Shadow;

namespace Services
{
    public sealed class ResourceLoader : IResourceLoader
    {
        private readonly Dictionary<string, UnityEngine.Object> _cacheAssets;

        public ResourceLoader()
        {
            _cacheAssets = new Dictionary<string, UnityEngine.Object>();
        }
        
        public PlayerCharacter LoadPlayerCharacter()
        {
            string key = nameof(PlayerCharacter);

            if (_cacheAssets.TryGetValue(key, out UnityEngine.Object value))
            {
                return value as PlayerCharacter;
            }

            PlayerCharacter playerCharacter = UnityEngine.Resources.Load<PlayerCharacter>($"Prefabs/{key}");
            _cacheAssets.Add(key, playerCharacter);
            return playerCharacter;
        }
        
        public ShadowCharacter LoadShadowCharacter()
        {
            string key = nameof(ShadowCharacter);

            if (_cacheAssets.TryGetValue(key, out UnityEngine.Object value))
            {
                return value as ShadowCharacter;
            }

            ShadowCharacter shadowCharacter = UnityEngine.Resources.Load<ShadowCharacter>($"Prefabs/{key}");
            _cacheAssets.Add(key, shadowCharacter);
            return shadowCharacter;
        }
        
    }
}