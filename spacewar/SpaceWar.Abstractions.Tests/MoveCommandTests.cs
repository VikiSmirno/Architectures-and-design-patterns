using Moq;

namespace SpaceWar.Abstractions.Tests;

public class MoveCommandTests
{
    [Fact]
    public void Constructor_NullRotatable_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new MoveCommand(null!));
    }

    [Fact]
    public void Execute_UpdatesPosition_Correctly()
    {
        var movable = new Mock<IMovable>();
        movable.SetupGet(obj => obj.Position).Returns(new Vector(12, 5));
        movable.SetupGet(obj => obj.Velocity).Returns(new Vector(-7, 3));
        var moveCommand = new MoveCommand(movable.Object);

        moveCommand.Execute();

        movable.VerifySet(obj => obj.Position = new Vector(5, 8), Times.Once);
    }

    [Fact]
    public void Execute_UpdatesPosition_GetPositionFail()
    {
        var movable = new Mock<IMovable>();
        movable.SetupGet(m => m.Position).Throws<Exception>();
        movable.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));
        var moveCommand = new MoveCommand(movable.Object);

        Assert.Throws<Exception>(() => moveCommand.Execute());
    }

    [Fact]
    public void Execute_UpdatesPosition_GetVelocityFail()
    {
        var movable = new Mock<IMovable>();
        movable.SetupGet(m => m.Position).Returns(new Vector(12, 5));
        movable.SetupGet(m => m.Velocity).Throws<Exception>();
        var moveCommand = new MoveCommand(movable.Object);

        Assert.Throws<Exception>(() => moveCommand.Execute());
    }

    [Fact]
    public void Execute_MoveObject_ImpossibleChangePosition()
    {
        var movable = new Mock<IMovable>();
        movable.SetupGet(m => m.Position).Returns(new Vector(12, 5));
        movable.SetupGet(m => m.Velocity).Returns(new Vector(7, -3));
        movable.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<InvalidOperationException>();
        var moveCommand = new MoveCommand(movable.Object);

        Assert.Throws<InvalidOperationException>(() => moveCommand.Execute());
    }
}
