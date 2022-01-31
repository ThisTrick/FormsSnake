using FormsSnake.Exception;
using FormsSnake.Model;
using Xunit;

namespace FormsSnake.Tests.ModelTests
{
    public class SnakeModelTests
    {
        [Fact]
        public void GetLengthAfterCreationReturn3()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            int length = snakeModel.GetLength();
            //Assert
            Assert.Equal(3, length);
        }

        [Fact]
        public void EatAnAppleReturnLengthEqual4()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            snakeModel.EatAnApple();
            int length = snakeModel.GetLength();
            //Assert
            Assert.Equal(4, length);
        }

        [Fact]
        public void HasAliveAfterCreationReturnTrue()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            bool isAlive = snakeModel.HasAlive();
            //Assert
            Assert.True(isAlive);
        }

        [Fact]
        public void HasAliveAfterDieReturnFalse()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            snakeModel.Die();
            bool isAlive = snakeModel.HasAlive();
            //Assert
            Assert.False(isAlive);
        }

        [Fact]
        public void HasAliveAfterRebornAfterDieReturnTrue()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            snakeModel.Die();
            snakeModel.Reborn();
            bool isAlive = snakeModel.HasAlive();
            //Assert
            Assert.True(isAlive);
        }

        [Fact]
        public void DieAfterDieReturnExeption()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            snakeModel.Die();
            //Assert
            Assert.Throws<ModelException>(() => snakeModel.Die());
        }

        [Fact]
        public void RebornBeforeDieReturnExeption()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            //Assert
            Assert.Throws<ModelException>(() => snakeModel.Reborn());
        }

        [Fact]
        public void GetLengthAfterDieReturnExeption()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            snakeModel.Die();
            //Assert
            Assert.Throws<ModelException>(() => snakeModel.GetLength());
        }

        [Fact]
        public void GetLengthAfterRebornReturn3()
        {
            //Arrange
            ISnakeModel snakeModel = new SnakeModel();
            //Act
            snakeModel.Die();
            snakeModel.Reborn();
            var length = snakeModel.GetLength();
            //Assert
            Assert.Equal(3, length);
        }

    }
}