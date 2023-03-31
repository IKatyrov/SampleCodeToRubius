namespace Character
{
    public interface ICharacter 
    {
        DistanceTracker DistanceTracker { get; }
        IMovable Movable { get; }
        void ChangeToRandomColor();
        void ChangeToGreenColor();
    }
}