namespace SpaceWar.Abstractions;

public class Angle
{
    private readonly int _angle;
    private readonly int _unitsPerCircle;
    public virtual int AngleValue => _angle % _unitsPerCircle;
    public Angle(int angle, int unitsPerCircle = 360)
    {
        if (unitsPerCircle == 0) throw new ArgumentException("Denumenator cannot be zero", nameof(unitsPerCircle));
        (_angle, _unitsPerCircle) = ReduceFraction(angle, unitsPerCircle);
    }
    private static int CalculateGCD(int x, int y) => y == 0 ? x : CalculateGCD(y, x % y);
    private static (int ReducedNumerator, int ReducedDenumenator) ReduceFraction(int numerator, int denumenator)
    {
        var gcd = CalculateGCD(numerator, denumenator);
        return (ReducedNumerator: numerator /= gcd, ReducedDenumenator: denumenator /= gcd);
    }
    public static Angle operator +(Angle x, Angle y)
    {
        if (x is null || y is null) throw new ArgumentNullException();
        var newNumerator = x._angle * y._unitsPerCircle + y._angle * x._unitsPerCircle;
        var newDenumenator = x._unitsPerCircle * y._unitsPerCircle;
        (newNumerator, newDenumenator) = ReduceFraction(newNumerator, newDenumenator);
        return new Angle(newNumerator, newDenumenator);
    }
    public bool Equals(Angle? other_angle) => other_angle is not null && AngleValue == other_angle.AngleValue;
    public override bool Equals(object? obj) => obj is Angle other_angle && Equals(other_angle);
    public static bool operator ==(Angle x, Angle y) => x is null ? y is null : x.Equals(y);
    public static bool operator !=(Angle x, Angle y) => !(x == y);
    public override int GetHashCode() => AngleValue.GetHashCode();
}