using System.Security.Cryptography;
using Moq;

namespace SpaceWar.Abstractions.Tests;

public class RotateCommandTests
{
    [Fact]
    public void Constructor_NullRotatable_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new RotateCommand(null!));
    }

    [Fact]
    public void Execute_UpdatesCurrentAngle_Correctly()
    {
        var rotatable = new Mock<IRotatable>();
        rotatable.SetupGet(r => r.CurrentAngle).Returns(new Angle(45));
        rotatable.SetupGet(r => r.RotationStep).Returns(new Angle(90));
        var rotateCommand = new RotateCommand(rotatable.Object);

        rotateCommand.Execute();

        rotatable.VerifySet(r => r.CurrentAngle = new Angle(135), Times.Once);
    }

    [Fact]
    public void Execute_UpdatesCurrentAngle_GetCurrentAngleFail()
    {
        var rotatable = new Mock<IRotatable>();
        rotatable.SetupGet(r => r.CurrentAngle).Throws<Exception>();
        rotatable.SetupGet(r => r.RotationStep).Returns(new Angle(90));
        var rotateCommand = new RotateCommand(rotatable.Object);

        Assert.Throws<Exception>(() => rotateCommand.Execute());
    }

    [Fact]
    public void Execute_UpdatesCurrentAngle_GetRotationStepFail()
    {
        var rotatable = new Mock<IRotatable>();
        rotatable.SetupGet(r => r.CurrentAngle).Returns(new Angle(45));
        rotatable.SetupGet(r => r.RotationStep).Throws<Exception>();
        var rotateCommand = new RotateCommand(rotatable.Object);

        Assert.Throws<Exception>(() => rotateCommand.Execute());
    }

    [Fact]
    public void Execute_UpdateCurrentAngle_ImpossibleRotateObject()
    {
        var rotatable = new Mock<IRotatable>();
        rotatable.SetupGet(r => r.CurrentAngle).Returns(new Angle(45));
        rotatable.SetupGet(r => r.RotationStep).Returns(new Angle(90));
        rotatable.SetupSet(r => r.CurrentAngle = It.IsAny<Angle>()).Throws<InvalidOperationException>();
        var rotateCommand = new RotateCommand(rotatable.Object);

        Assert.Throws<InvalidOperationException>(() => rotateCommand.Execute());
    }
}
