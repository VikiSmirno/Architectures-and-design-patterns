using Hwdtech;

namespace SpaceWar.Abstractions;

public class EndCommand : ICommand
{
    private readonly ICommandEndable _cmdEndable;

    public EndCommand(ICommandEndable cmdEndable)
    {
        _cmdEndable = cmdEndable;
    }

    public void Execute()
    {
        var command = _cmdEndable.Command;
        IoC.Resolve<ICommand>("DeleteProperties", command, _cmdEndable.Properties).Execute();
        var emptyCmd = IoC.Resolve<ICommand>("EmptyCommand");
        IoC.Resolve<IInjectableCommand>("Command.Inject", command, emptyCmd);
    }
}
