using Hwdtech;

namespace SpaceWar.Abstractions;

public class VelocityChangableAdapter : IVelocityChangable
{
    private readonly IUObject _uObject;
    public VelocityChangableAdapter(IUObject uObject)
    {
        _uObject = uObject;
    }
    public Vector Velocity
    {
        get => IoC.Resolve<Vector>("VelocityChangable.Veloity.Get", _uObject);
        set => IoC.Resolve<ICommand>("VelocityChangable.Veloity.Set", _uObject, value).Execute();
    }
}