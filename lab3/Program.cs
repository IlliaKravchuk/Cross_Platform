using lab3;

internal class Program
{
    static void Main(string[] args)
    {
		File.WriteAllText("INPUT.TXT", "8 10\n" +
                                 "##########\n" +
                                 "#.#...##.#\n" +
                                 "#.#..###.#\n" +
                                 "#.#.##...#\n" +
                                 "#.......##\n" +
                                 "#...###..#\n" +
                                 "#....T#..#\n" +
                                 "##########\n");
        CalculateFile.ProcessFiles();
    }
}