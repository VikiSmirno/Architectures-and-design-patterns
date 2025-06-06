namespace SpaceWar.Abstractions;

public interface IUObject
{
    object GetProperty(String key);
    void SetProperty(String key, object value);
}