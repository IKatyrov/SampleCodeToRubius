namespace Abilities
{
    public interface IAbility<in T>
    {
        public bool CheckCondition(T owner);
        public void TriggerAbility(T owner);
    }
}