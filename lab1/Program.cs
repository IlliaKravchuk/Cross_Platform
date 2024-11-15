using lab1;

internal class Program
{
    static void Main(string[] args)
    {
		File.WriteAllText("INPUT.TXT", "10 3\n11 21 27");
        CalculateFile.ProcessFiles();
    }
}