namespace SpaceWar.Abstractions.Tests;

public class AngleTests
{
    [Fact]
    public void Constructor_UnitsPerCircleEqualZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Angle(30, 0));
    }

    [Fact]
    public void OperatorPlus_AngleEqualsNull_ThrowsArgumentNullException()
    {
        var x = new Angle(30);
        Angle? nullAngle = null;

        Assert.Throws<ArgumentNullException>(() => x + nullAngle!);
        Assert.Throws<ArgumentNullException>(() => nullAngle! + x);
    }

    [Fact]
    public void OperatorPlus_AddAngles_Correctly()
    {
        var angle1 = new Angle(30);
        var angle2 = new Angle(30);

        var sumResult = angle1 + angle2;

        Assert.Equal(new Angle(60), sumResult);
    }
    [Fact]
    public void OperatorPlus_AddAnglesWithDifferentUnits_ThrowsException()
    {
        var angle1 = new Angle(30, 360);
        var angle2 = new Angle(30, 180);
        var sumResult = angle1 + angle2;

        Assert.Equal(new Angle(90), angle1 + angle2);
    }
    [Fact]
    public void OperatorDoubleEqual_CompareAngles_EqualAngles()
    {
        var angle1 = new Angle(30);
        var angle2 = new Angle(390);

        Assert.True(angle1 == angle2);
    }

    [Fact]
    public void OperatorDoubleEqual_CompareAngleWithNull_False()
    {
        var angle = new Angle(30);
        Angle? nullable = null;

        Assert.False(angle == nullable!);
        Assert.False(nullable! == angle);
    }

    [Fact]
    public void OperatorNotEqual_CompareAngles_NotEqualAngles()
    {
        var angle1 = new Angle(30);
        var angle2 = new Angle(300);

        Assert.True(angle1 != angle2);
    }
    [Fact]
    public void Equals_CompareAngles_Correctly()
    {
        var angle1 = new Angle(30);
        var angle2 = new Angle(390);

        Assert.True(angle1.Equals(angle2));
    }
    [Fact]
    public void Equals_CompareAngleWithNull_False()
    {
        var angle1 = new Angle(30);
        Angle? nullable = null;

        Assert.False(angle1.Equals(nullable));
    }

    [Fact]
    public void Equals_CompareAngleWithOtherObject_False()
    {
        var angle = new Angle(30);
        var vector = new Vector(30);

        Assert.False(angle.Equals(vector));
    }

    [Fact]
    public void GetHashCode_CompareAngles_Correctly()
    {
        var angle1 = new Angle(30);
        var angle2 = new Angle(390);

        Assert.True(angle1.GetHashCode() == angle2.GetHashCode());
    }
    [Fact]
    public void GetHashCode_CompareNotEqualAngles_HashDoesNotMatch()
    {
        var angle1 = new Angle(30);
        var angle2 = new Angle(300);

        Assert.True(angle1.GetHashCode() != angle2.GetHashCode());
    }

}