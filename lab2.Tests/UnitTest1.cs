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
        [Fact]
        public void Test_InvalidNumberOfElements_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "100 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 80 81 82 83 84 85 86 87 88 89 90 91 92 93 94 95 96 97 98 99 100");

            // Act & Assert
            Exception ex = Assert.Throws<Exception>(() => CalculateFile.ProcessFiles());
            Assert.Equal("Invalid number of elements (must be between 1 and 100)", ex.Message);
        }

        [Fact]
        public void Test_InvalidElementValue_ShouldThrowException()
        {
            // Arrange
            string inputFilePath = "INPUT.TXT";
            File.WriteAllText(inputFilePath, "3 1001 2 3");

            // Act & Assert
            Exception ex = Assert.Throws<Exception>(() => CalculateFile.ProcessFiles());
            Assert.Equal("Invalid number in the array (must be between 1 and 1000)", ex.Message);
        }
    }
}