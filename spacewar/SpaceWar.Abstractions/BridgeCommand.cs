namespace SpaceWar.Abstractions;

public class BridgeCommand : ICommand, IInjectableCommand
{
    private ICommand internalCommand;
    public BridgeCommand(ICommand command)
    {
        internalCommand = command;
    }
    public void Inject(ICommand other)
    {
        internalCommand = other;
    }
    public void Execute()
    {
        internalCommand.Execute();
    }
}
