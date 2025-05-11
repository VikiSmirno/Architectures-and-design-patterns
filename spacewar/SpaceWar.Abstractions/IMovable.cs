namespace SpaceWar.Abstractions;

public interface IMovable
{
    public Vector Position { get; set; }
    public Vector Velocity { get; }
}

