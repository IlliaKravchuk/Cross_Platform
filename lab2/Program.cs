using lab2;

internal class Program
{
    static void Main(string[] args)
    {
		string inputFilePath = "INPUT.TXT";
        File.WriteAllText(inputFilePath, "43 2 5 4");
        CalculateFile.ProcessFiles();
    }
}
