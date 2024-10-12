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

            // Записуємо вхідні дані
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

            // Записуємо вхідні дані
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
    }
}