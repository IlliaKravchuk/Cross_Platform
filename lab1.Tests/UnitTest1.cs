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
    }
}