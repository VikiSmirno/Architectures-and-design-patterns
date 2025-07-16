using Hwdtech;

namespace SpaceWar.Abstractions;

public class StartCommand : ICommand
{
    private readonly ICommandStartable _cmdStartable;
    public StartCommand(ICommandStartable cmdStartable)
    {
        _cmdStartable = cmdStartable;
    }
    public void Execute()
    {
        var actionType = (string)_cmdStartable.properties["action"];
        var handler = IoC.Resolve<IOperationHandler>($"Operation.Handler.{actionType}");
        var cmd = handler.Handle(_cmdStartable);
        _cmdStartable.Queue.Add(cmd);
    }
}