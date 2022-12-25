using System.Drawing;
using FormsSnake;
using FormsSnake.Models;
using Xunit;

namespace SnakeGame.Tests.ModelsTests;

public class PlaygroundModelTests
{
    private PlaygroundModel _model;
    
    public PlaygroundModelTests()
    {
        _model = new PlaygroundModel();
    }
    
    [Fact]
    public void CreatePlaygroundModel_DefaultSettingsCorrect()
    {
        var model = new PlaygroundModel();
        
        Assert.NotNull(model);
        Assert.Equal(576, model.Space);
        Assert.Equal(32, model.Step);
        Assert.Equal(new Point(1, 0), model.CurrentDirection);
    }
    
    [Fact]
    public void SetDefaultDirection_DirectionEqualRight()
    {
        _model.SetDefaultDirection();
        
        Assert.Equal(new Point(1, 0),_model.CurrentDirection);
    }
    
    [Fact]
    public void SetDirectionLeftAfterTop_DirectionEqualTop()
    {
        _model.SetDirection(Direction.Left);
        _model.SetDirection(Direction.Top);
        
        Assert.Equal(new Point(0, -1), _model.CurrentDirection);
    }
    
    [Fact]
    public void SetDirectionLeftAfterBottom_DirectionEqualBottom()
    {
        _model.SetDirection(Direction.Left);
        _model.SetDirection(Direction.Bottom);
        
        Assert.Equal(new Point(0, 1), _model.CurrentDirection);
    }
    
    [Fact]
    public void SetDirectionTopAfterLeft_DirectionEqualLeft()
    {
        _model.SetDirection(Direction.Top);
        _model.SetDirection(Direction.Left);
        
        Assert.Equal(new Point(-1, 0), _model.CurrentDirection);
    }
    
    [Fact]
    public void SetDirectionTopAfterRight_DirectionEqualRight()
    {
        _model.SetDirection(Direction.Top);
        _model.SetDirection(Direction.Right);
        
        Assert.Equal(new Point(1, 0), _model.CurrentDirection);
    }
    
    
    [Fact]
    public void SetDirectionBottomAfterTop_DirectionEqualBottom()
    {
        _model.SetDirection(Direction.Bottom);
        _model.SetDirection(Direction.Top);
        
        Assert.Equal(new Point(0, 1), _model.CurrentDirection);
    }
    
    [Fact]
    public void SetDirectionTopAfterBottom_DirectionEqualTop()
    {
        _model.SetDirection(Direction.Top);
        _model.SetDirection(Direction.Bottom);
        
        Assert.Equal(new Point(0, -1), _model.CurrentDirection);
    }
    
    [Fact]
    public void SetDirectionRightAfterLeft_DirectionEqualRight()
    {
        _model.SetDirection(Direction.Right);
        _model.SetDirection(Direction.Left);
        
        Assert.Equal(new Point(1, 0), _model.CurrentDirection);
    }
    
    [Fact]
    public void SetDirectionTopAfterLeftAfterRight_DirectionEqualLeft()
    {
        _model.SetDirection(Direction.Top);
        _model.SetDirection(Direction.Left);
        _model.SetDirection(Direction.Right);
        
        Assert.Equal(new Point(-1, 0), _model.CurrentDirection);
    }
}