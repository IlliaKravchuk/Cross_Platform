namespace lab3.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";
            File.WriteAllText(inputFilePath, "8 10\n" +
                                             "##########\n" +
                                             "#.#...##.#\n" +
                                             "#.#..###.#\n" +
                                             "#.#.##...#\n" +
                                             "#.......##\n" +
                                             "#...###..#\n" +
                                             "#....T#..#\n" +
                                             "##########\n");

            // Act
            CalculateFile.ProcessFiles();

            // Assert
            string result = File.ReadAllText(outputFilePath);
            Assert.Equal("12No", result);
        }
        [Fact]
        public void Test2()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";
            File.WriteAllText(inputFilePath, "8 10\n" +
                                             "##########\n" +
                                             "#.#...##.#\n" +
                                             "#.#..###.#\n" +
                                             "#.#.##...#\n" +
                                             "#....... #\n" +
                                             "##..####..\n" +
                                             "##....T#..\n" +
                                             "##########\n");

            // Act
            CalculateFile.ProcessFiles();

            // Assert
            string result = File.ReadAllText(outputFilePath);
            Assert.Equal("12Yes", result);
        }

        [Fact]
        public void Test_InvalidNValue_TooLow_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "3 10\n");

            // Act & Assert
            var exception = Assert.Throws<System.Exception>(() => CalculateFile.ProcessFiles());
            Assert.Equal("Invalid value for N. It must be an integer between 4 and 1000.", exception.Message);
        }

        [Fact]
        public void Test_InvalidNValue_TooHigh_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "1001 10\n");

            // Act & Assert
            var exception = Assert.Throws<System.Exception>(() => CalculateFile.ProcessFiles());
            Assert.Equal("Invalid value for N. It must be an integer between 4 and 1000.", exception.Message);
        }

        [Fact]
        public void Test_InvalidMValue_TooLow_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "10 3\n");

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => CalculateFile.ProcessFiles());
            Assert.Equal("Invalid value for M. It must be an integer between 4 and 1000.", exception.Message);
        }

        [Fact]
        public void Test_InvalidMValue_TooHigh_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "10 1001\n");

            // Act & Assert
            var exception = Assert.Throws<System.Exception>(() => CalculateFile.ProcessFiles());
            Assert.Equal("Invalid value for M. It must be an integer between 4 and 1000.", exception.Message);
        }
    }
}