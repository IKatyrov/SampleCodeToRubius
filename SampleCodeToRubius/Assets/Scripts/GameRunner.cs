using Character.Player;
using Services;
using UnityEngine;
using Zenject;

public sealed class GameRunner : MonoBehaviour
{
    [Inject] private readonly ICharactersFactory _charactersFactory;
    [Inject] private readonly ICharactersProvider _charactersProvider;

    private void Start()
    {
        PlayerCharacter playerCharacter = _charactersFactory.Create<PlayerCharacter>();
        playerCharacter.ReturnToStartPosition();
        _charactersProvider.PlayerCharacter = playerCharacter;
    }
}