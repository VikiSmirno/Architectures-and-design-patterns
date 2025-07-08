namespace SpaceWar.Abstractions;

public interface IInjectableCommand
{
    public void Inject(ICommand obj);
}
