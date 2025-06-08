using Hwdtech;

namespace SpaceWar.Abstractions;

public class RotatableAdapter : IRotatable
{
    private readonly IUObject _uObject;
    public RotatableAdapter(IUObject uObject)
    {
        _uObject = uObject;
    }
    public Angle CurrentAngle
    {
        get => IoC.Resolve<Angle>("Rotatble.CurrentAngle", _uObject);
        set => IoC.Resolve<ICommand>("Rotatable.CurrentAngle.Set", _uObject);
    }

    public Angle RotationStep
    {
        get => IoC.Resolve<Angle>("Rotatable.RotationStep", _uObject);
    }

}