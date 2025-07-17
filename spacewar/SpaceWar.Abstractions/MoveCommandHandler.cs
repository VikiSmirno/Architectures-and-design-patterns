using Hwdtech;

namespace SpaceWar.Abstractions;

public class MoveCommandHandler : IOperationHandler
{
    public ICommand Handle(ICommandStartable cmdStartable)
    {
        var movingObject = cmdStartable.Order;
        var velocityAdapter = IoC.Resolve<IVelocityChangable>("Adapter.Velocity", movingObject);
        var velocity = (Vector)cmdStartable.properties["velocity"];
        IoC.Resolve<ICommand>("SetVelocityCommand", velocityAdapter, velocity).Execute();
        var movableAdapter = IoC.Resolve<IMovable>("Adapter.Movable", movingObject);
        var moveCmd = IoC.Resolve<ICommand>("MoveCommand", movableAdapter);
        return moveCmd;
    }
}