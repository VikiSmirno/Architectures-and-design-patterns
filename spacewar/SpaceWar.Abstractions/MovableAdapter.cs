using Hwdtech;

namespace SpaceWar.Abstractions;

public class MovableAdapter : IMovable
{
    private readonly IUObject _uObject;
    public MovableAdapter(IUObject uObject)
    {
        _uObject = uObject;
    }

    public Vector Position
    {
        get => IoC.Resolve<Vector>("Movable.Position", _uObject);
        set => IoC.Resolve<ICommand>("Movable.Position.Set", _uObject, value).Execute();
    }
    public Vector Velocity
    {
        get => IoC.Resolve<Vector>("Movable.Velocity", _uObject);
    }

}