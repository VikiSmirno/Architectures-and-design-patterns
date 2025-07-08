namespace SpaceWar.Abstractions;

public interface ICommandStartable
{
    IUObject Order { get; }
    Dictionary<string, object> properties { get; }
    IQueue Queue { get; }
}
