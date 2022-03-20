using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throw.UnitTests.ValidatableExtensions
{
    [TestClass]
    public class ValidatableExtensions
    {
        [TestMethod]
        public void ThrowIfContainsKey_WhenDictionaryContainsKey_ShouldThrow()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>
            {
                ["key1"] = "value1",
                ["key2"] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey("key1");

            //Assert
            action.Should().Throw();
        }
        
        [TestMethod]
        public void ThrowIfContainsKey_WhenDictionaryDoesNotContainKey_ShouldNotThrow()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>
            {
                ["key1"] = "value1",
                ["key2"] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey("key3");

            //Assert
            action.Should().NotThrow();
        }

        [TestMethod]
        public void ThrowIfNotContainsKey_WhenDictionaryContainsKey_ShouldNotThrow()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>
            {
                ["key1"] = "value1",
                ["key2"] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey("key3");

            //Assert
            action.Should().NotThrow();
        }
        
        [TestMethod]
        public void ThrowIfNotContainsKey_WhenDictionaryDoesNotContainKey_ShouldThrow()
        {
            //Arrange
            var dictionary = new Dictionary<string, string>
            {
                ["key1"] = "value1",
                ["key2"] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfNotContainsKey("key3");

            //Assert
            action.Should().Throw();
        }
        
        [TestMethod]
        public void ThrowIfContainsKey_WhenDictionaryContainsIntegerKey_ShouldThrow()
        {
            //Arrange
            var dictionary = new Dictionary<int, string>
            {
                [1] = "value1",
                [2] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey("1");

            //Assert
            action.Should().Throw();
        }
        
        [TestMethod]
        public void ThrowIfContainsKey_WhenDictionaryDoesNotContainIntegerKey_ShouldNotThrow()
        {
            //Arrange
            var dictionary = new Dictionary<int, string>
            {
                [1] = "value1",
                [2] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey("3");

            //Assert
            action.Should().NotThrow();
        }

        [TestMethod]
        public void ThrowIfNotContainsKey_WhenDictionaryContainsIntegerKey_ShouldNotThrow()
        {
            //Arrange
            var dictionary = new Dictionary<int, string>
            {
                [1] = "value1",
                [2] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey(3);

            //Assert
            action.Should().NotThrow();
        }
        
        [TestMethod]
        public void ThrowIfNotContainsKey_WhenDictionaryDoesNotContainIntegerKey_ShouldThrow()
        {
            //Arrange
            var dictionary = new Dictionary<int, string>
            {
                [1] = "value1",
                [2] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfNotContainsKey(3);

            //Assert
            action.Should().Throw();
        }

        [TestMethod]
        public void ThrowIfContainsKey_WhenDictionaryContainsObjectKey_ShouldThrow()
        {
            //Arrange
            var dictionary = new Dictionary<object, string>
            {
                [new object()] = "value1",
                [new object()] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey(dictionary.First());

            //Assert
            action.Should().Throw();
        }

        [TestMethod]
        public void ThrowIfContainsKey_WhenDictionaryDoesNotContainObjectKey_ShouldNotThrow()
        {
            //Arrange
            var dictionary = new Dictionary<object, string>
            {
                [new object()] = "value1",
                [new object()] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey(new object());

            //Assert
            action.Should().NotThrow();
        }

        [TestMethod]
        public void ThrowIfNotContainsKey_WhenDictionaryContainsObjectKey_ShouldNotThrow()
        {
            //Arrange
            var dictionary = new Dictionary<object, string>
            {
                [new object()] = "value1",
                [new object()] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfContainsKey(dictionary.First());

            //Assert
            action.Should().NotThrow();
        }

        [TestMethod]
        public void ThrowIfNotContainsKey_WhenDictionaryDoesNotContainObjectKey_ShouldThrow()
        {
            //Arrange
            var dictionary = new Dictionary<object, string>
            {
                [new object()] = "value1",
                [new object()] = "value2",
            };

            //Act
            var action = () => dictionary.Throw().IfNotContainsKey(new object());

            //Assert
            action.Should().Throw();
        }
    }
}
