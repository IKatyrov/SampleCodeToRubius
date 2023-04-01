using Abilities;
using UnityEngine;
using Zenject;
using ILogger = Services.ILogger;

namespace Character.Shadow
{
    [RequireComponent(typeof(DistanceTracker))]
    [RequireComponent(typeof(AbilityFactory))]
    [RequireComponent(typeof(ShadowMove))]
    public sealed class ShadowCharacter : MonoBehaviour, ICharacter
    {
        [Inject] private readonly ILogger _logger;
        
        [SerializeField] private Renderer _renderer;
        [Space]
        [SerializeField] private DistanceTracker _distanceTracker;
        [SerializeField] private AbilityFactory _abilityFactory;
        [SerializeField] private ShadowMove _shadowMove;

        public DistanceTracker DistanceTracker => _distanceTracker;
        public IMovable Movable => _shadowMove;
        
        private void Start()
        {
            _distanceTracker ??= GetComponent<DistanceTracker>();
            _abilityFactory ??= GetComponent<AbilityFactory>();
            _shadowMove ??= GetComponent<ShadowMove>();
        }
        
        private void Update()
        {
            Movable.Move();
            DistanceTracker.CalculateDistance(Movable.Direction, Movable.Speed);
            CheckAbilities();
        }

        public void ChangeToRandomColor()
        {
            if (!Movable.CurrentStep.ChangedColor.HasValue)
            {
                return;
            }
            
            _renderer.material.color = Movable.CurrentStep.ChangedColor.Value;
                
#if UNITY_EDITOR
            string message = $"Двойник {gameObject.name} сменил цвет на тот что был у игрока";
            _logger.PrintLog(message);
#endif
        }

        public void ChangeToGreenColor()
        {
            if (_renderer.material.color.Equals(Color.green))
            {
                return;
            }
            
            _renderer.material.color = Color.green;
            
#if UNITY_EDITOR
            string message = $"Двойник {gameObject.name} сменил цвет на зелёный";
            _logger.PrintLog(message);
#endif
          
        }

        private void CheckAbilities()
        {
            foreach (IAbility<ICharacter> ability in _abilityFactory.Abilities)
            {
                if (ability.CheckCondition(this))
                {
                    ability.TriggerAbility(this);
                }
            }   
        }
    }
}