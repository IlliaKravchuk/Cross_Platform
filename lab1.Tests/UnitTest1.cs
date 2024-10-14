using Microsoft.VisualStudio.TestPlatform.TestHost;
using lab1;

namespace lab1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";
            File.WriteAllText(inputFilePath, "10 3\n11 21 27");

            // Act
            CalculateFile.ProcessFiles();

            // Assert
            string result = File.ReadAllText(outputFilePath);
            Assert.Equal("1", result);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";
            File.WriteAllText(inputFilePath, "5 3\n6 10 27");

            // Act
            CalculateFile.ProcessFiles();

            // Assert
            string result = File.ReadAllText(outputFilePath);
            Assert.Equal("2", result);
        }
        [Fact]
        public void Test_IncorrectLength_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "10 2\n100 200 300");

            // Act & Assert
            Exception ex = Assert.Throws<Exception>(() => CalculateFile.ProcessFiles());

            // Assert message
            Assert.Equal("Incorrect massive length(massive has less or more values)", ex.Message);
        }

        [Fact]
        public void Test_InvalidValue_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "10 3\n100 50000 300"); // 50000 exceeds the allowed range

            // Act & Assert
            Exception ex = Assert.Throws<Exception>(() => CalculateFile.ProcessFiles());

            // Assert message
            Assert.Equal("Incorrect value in massive", ex.Message);
        }

        [Fact]
        public void Test_LargerThanAllowedInput_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "3201 3\n100 200 300"); // l exceeds the allowed limit

            // Act & Assert
            Exception ex = Assert.Throws<Exception>(() => CalculateFile.ProcessFiles());

            // Assert message
            Assert.Equal("Incorrect input L or N", ex.Message);
        }
    }
}