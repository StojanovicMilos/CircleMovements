namespace CircleMovements.Shape
{
    public interface IShape
    {
        int X { get; }
        int Y { get; }
        void UpdateState();
    }
}