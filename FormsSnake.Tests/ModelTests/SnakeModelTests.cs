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
            ISnakeModel snakeModel = CreateSnakeModel();
            //Act
            int length = snakeModel.GetLength();
            //Assert
            Assert.Equal(3, length);
        }

        [Fact]
        public void EatAnAppleReturnLengthEqual4()
        {
            //Arrange
            ISnakeModel snakeModel = CreateSnakeModel();
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
            ISnakeModel snakeModel = CreateSnakeModel();
            //Act
            bool isAlive = snakeModel.HasAlive();
            //Assert
            Assert.True(isAlive);
        }

        [Fact]
        public void HasAliveAfterDieReturnFalse()
        {
            //Arrange
            ISnakeModel snakeModel = CreateDeathSnakeModel();
            //Act
            bool isAlive = snakeModel.HasAlive();
            //Assert
            Assert.False(isAlive);
        }

        [Fact]
        public void HasAliveAfterRebornAfterDieReturnTrue()
        {
            //Arrange
            ISnakeModel snakeModel = CreateRebornSnakeModel();
            //Act
            bool isAlive = snakeModel.HasAlive();
            //Assert
            Assert.True(isAlive);
        }

        [Fact]
        public void DieAfterDieReturnModelExeption()
        {
            //Arrange and Act
            ISnakeModel snakeModel = CreateDeathSnakeModel();
            //Assert
            Assert.Throws<ModelException>(() => snakeModel.Die());
        }

        [Fact]
        public void RebornBeforeDieReturnModelExeption()
        {
            //Arrange
            ISnakeModel snakeModel = CreateSnakeModel();
            //Act
            //Assert
            Assert.Throws<ModelException>(() => snakeModel.Reborn());
        }

        [Fact]
        public void GetLengthAfterDieReturnModelExeption()
        {
            //Arrange and Act
            ISnakeModel snakeModel = CreateDeathSnakeModel();
            //Assert
            Assert.Throws<ModelException>(() => snakeModel.GetLength());
        }

        [Fact]
        public void GetLengthAfterRebornReturn3()
        {
            //Arrange
            ISnakeModel snakeModel = CreateRebornSnakeModel();
            //Act
            var length = snakeModel.GetLength();
            //Assert
            Assert.Equal(3, length);
        }

        private ISnakeModel CreateSnakeModel()
        {
            return new SnakeModel();
        } 

        private ISnakeModel CreateDeathSnakeModel()
        {
            var snakeModel = CreateSnakeModel();
            snakeModel.Die();
            return snakeModel;
        }

        private ISnakeModel CreateRebornSnakeModel()
        {
            var snakeModel = CreateDeathSnakeModel();
            snakeModel.Reborn();
            return snakeModel;
        }

    }
}