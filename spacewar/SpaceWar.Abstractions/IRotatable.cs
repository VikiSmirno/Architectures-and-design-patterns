namespace SpaceWar.Abstractions;

public interface IRotatable
{
    Angle CurrentAngle { get; set; }
    Angle RotationStep { get; }
}
