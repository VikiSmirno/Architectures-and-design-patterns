namespace SpaceWar.Abstractions;

public interface ICommandStartable
{
    IUObject Order { get; }
    Dictionary<string, object> Properties { get; }
    IQueue Queue { get; }
}
