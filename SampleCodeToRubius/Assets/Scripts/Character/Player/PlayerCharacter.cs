using Abilities;
using UnityEngine;
using Zenject;
using ILogger = Services.ILogger;

namespace Character.Player
{
    [RequireComponent(typeof(DistanceTracker))]
    [RequireComponent(typeof(AbilityFactory))]
    [RequireComponent(typeof(PlayerMove))]
    public sealed class PlayerCharacter : MonoBehaviour, ICharacter
    {
        [Inject] private readonly ILogger _logger;
        
        [SerializeField] private Renderer _renderer;
        [Space]
        [SerializeField] private DistanceTracker _distanceTracker;
        [SerializeField] private AbilityFactory _abilityFactory;
        [SerializeField] private PlayerMove _playerMove;
        
        public DistanceTracker DistanceTracker => _distanceTracker;
        public IMovable Movable => _playerMove;

        private void Start()
        {
            _distanceTracker ??= GetComponent<DistanceTracker>();
            _abilityFactory ??= GetComponent<AbilityFactory>();
            _playerMove ??= GetComponent<PlayerMove>();
        }

        private void Update()
        {
            Movable.Move();
            DistanceTracker.CalculateDistance(Movable.Direction, Movable.Speed);
            CheckAbilities();
        }

        public void ChangeToRandomColor()
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);
            _renderer.material.color = newColor;
            AddColorStep(newColor);
            
#if UNITY_EDITOR
            string message = $"Игрок {gameObject.name} сменил цвет на случайный";
            _logger.PrintLog(message);
#endif
            
        }

        public void ChangeToGreenColor()
        {
            _renderer.material.color = Color.green;
            
#if UNITY_EDITOR
            string message = $"Игрок {gameObject.name} сменил цвет на зелёный";
            _logger.PrintLog(message);
#endif
            
        }

        public void ReturnToStartPosition()
        {
            transform.position = Vector3.up;
            transform.rotation = Quaternion.identity;
        }

        public void AddColorStep(Color color)
        {
            Step lastStep = Movable.CurrentStep;
            
            if (lastStep != null)
            {
                lastStep.ChangedColor = color;
            }
        }

        private void CheckAbilities()
        {
            foreach (IAbility<PlayerCharacter> ability in _abilityFactory.Abilities)
            {
                if (ability.CheckCondition(this))
                {
                    ability.TriggerAbility(this);
                }
            }   
        }
    }
}