namespace SpaceWar.Abstractions;

public interface IOperationHandler
{
    ICommand Handle(ICommandStartable cmdStartable);
}
