namespace SpaceWar.Abstractions;

public class ChangeVelocityCommand : ICommand
{
    private readonly IVelocityChangable _velocityChangable;
    private readonly Vector _newVelocity;
    public ChangeVelocityCommand(IVelocityChangable velocityChangable, Vector newVelocity)
    {
        _velocityChangable = velocityChangable;
        _newVelocity = newVelocity;
    }
    public void Execute()
    {
        _velocityChangable.Velocity = _newVelocity;
    }
}