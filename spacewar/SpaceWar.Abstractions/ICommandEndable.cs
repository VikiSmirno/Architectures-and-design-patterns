namespace SpaceWar.Abstractions;

public interface ICommandEndable
{
    IUObject Command { get; }
    IEnumerable<string> Properties { get; }
    IQueue Queue { get; }
}
