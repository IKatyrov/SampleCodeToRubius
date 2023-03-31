using Character;
using Character.Player;
using Character.Shadow;
using Zenject;

namespace Services
{
    public sealed class InputListener : ITickable
    {
        [Inject] private readonly ICharactersProvider _charactersProvider;
        [Inject] private readonly ICharactersFactory _charactersFactory;

        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.R))
            {
                ReturnedPlayerStartPosition();
                CreateShadow();
            }
        }

        private void ReturnedPlayerStartPosition()
        {
            _charactersProvider.PlayerCharacter.ReturnToStartPosition();
        }

        private void CreateShadow()
        {
            PlayerCharacter playerCharacter = _charactersProvider.PlayerCharacter;
            
            UnityEngine.Vector3 startPosition = playerCharacter.transform.localPosition;
            UnityEngine.Quaternion startRotation = playerCharacter.transform.localRotation;
            
            ShadowCharacter shadowCharacter = _charactersFactory.Create<ShadowCharacter>(startPosition, startRotation);

            foreach (Step stepPlayer in playerCharacter.Movable.Steps)
            {
                shadowCharacter.Movable.Steps.Enqueue(stepPlayer);
            }

            playerCharacter.Movable.Steps.Clear();
            UnityEngine.Debug.Log("");
        }
    }
}