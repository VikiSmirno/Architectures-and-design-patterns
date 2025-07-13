namespace SpaceWar.Abstractions;

public interface IOperationHandler
{
    void Handle(ICommandStartable cmdStartable);
}
