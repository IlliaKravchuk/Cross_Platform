namespace lab2.Tests
{
    public class UnitTest2
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";
            File.WriteAllText(inputFilePath, "43 2 5 4");

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
            File.WriteAllText(inputFilePath, "65 5 5 5 5 5");

            // Act
            CalculateFile.ProcessFiles();

            // Assert
            string result = File.ReadAllText(outputFilePath);
            Assert.Equal("1", result); 
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";
            File.WriteAllText(inputFilePath, "92 1 3 2 9 1 2 3 1");

            // Act
            CalculateFile.ProcessFiles();

            // Assert
            string result = File.ReadAllText(outputFilePath);
            Assert.Equal("1", result); 
        }

        [Fact]
        public void Test4()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";
            File.WriteAllText(inputFilePath, "102 5 3 12 4 6 13 7 1 3");

            // Act
            CalculateFile.ProcessFiles();

            // Assert
            string result = File.ReadAllText(outputFilePath);
            Assert.Equal("1", result); 
        }
    }
}