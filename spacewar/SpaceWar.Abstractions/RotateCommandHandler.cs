using Hwdtech;

namespace SpaceWar.Abstractions;

public class RotateCommandHandler : IOperationHandler
{
    public ICommand Handle(ICommandStartable cmdStartable)
    {
        var rotatableObject = cmdStartable.Order;
        var rotatableAdapter = IoC.Resolve<IRotatable>("Adapter.Rotatable", rotatableObject);
        var rotateCmd = IoC.Resolve<ICommand>("RotateCommand", rotatableAdapter);
        return rotateCmd;
    }
}