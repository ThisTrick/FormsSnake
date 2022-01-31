using FormsSnake.Exception;
using Xunit;

namespace FormsSnake.Tests.ExceptionTests
{
    public class ModelExceptionTests
    {
        [Fact]
        public void CtorWithModelName()
        {
            //Arrange and Act
            ModelException modelException = new ModelException("TestModel");
            //Assert
            Assert.Equal("TestModel Exception.", modelException.Message);
        }

        [Fact]
        public void CtorWithModelNameAndMessage()
        {
            //Arrange and Act
            ModelException modelException = new ModelException("TestModel", "Test message");
            //Assert
            Assert.Equal("TestModel Exception: Test message.", modelException.Message);
        }

        [Fact]
        public void CtorWithModelNameAndMessageAndInerException()
        {
            //Arrange and Act
            ModelException modelException = new ModelException("TestModel", "Test message", new System.Exception());
            //Assert
            Assert.Equal("TestModel Exception: Test message.", modelException.Message);
        }

    }
}
