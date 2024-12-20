﻿using McMaster.Extensions.CommandLineUtils;
using System.Runtime.InteropServices;
using System;
using Lab4.LabsLibrary;
using static Lab4.LabsLibrary.LabsLibrary;

[Command(Name = "mylabs", Description = "Console application for running labs.")]
[Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
class Program
{
    public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

    private void OnExecute(CommandLineApplication app, IConsole console)
    {
        console.WriteLine("Specify a command to run (version, run, set-path).");
    }
}

[Command(Name = "version", Description = "Display version information.")]
class VersionCommand
{
    private void OnExecute(IConsole console)
    {
        console.WriteLine("Author: Your Name");
        console.WriteLine("Version: 1.0.0");
    }
}

[Command(Name = "run", Description = "Run specified lab.")]
class RunCommand
{
    [Option("-I|--input", "Input file path", CommandOptionType.SingleValue)]
    public string InputFile { get; set; }

    [Option("-o|--output", "Output file path", CommandOptionType.SingleValue)]
    public string OutputFile { get; set; }

    [Argument(0, "lab", "Lab to run (lab1, lab2, lab3)")]
    public string Lab { get; set; }

    private void OnExecute(CommandLineApplication app, IConsole console)
    {
        if (string.IsNullOrEmpty(Lab))
        {
            console.WriteLine("Error: No lab specified.");
            app.ShowHelp();
            return;
        }

        string inputPath = InputFile ?? Environment.GetEnvironmentVariable("LAB_PATH") + "/INPUT.TXT";
        string outputPath = OutputFile ?? "OUTPUT.TXT";

        if (!File.Exists(inputPath))
        {
            console.WriteLine($"Error: Input file not found at path '{inputPath}'");
            return;
        }

        switch (Lab.ToLower())
        {
            case "lab1":
                LabsLibrary.Lab1 lab1 = new LabsLibrary.Lab1();
                lab1.Run(inputPath, outputPath);
                break;
            case "lab2":
                LabsLibrary.Lab2 lab2 = new LabsLibrary.Lab2();
                lab2.Run(inputPath, outputPath);
                break;
            case "lab3":
                LabsLibrary.Lab3 lab3 = new LabsLibrary.Lab3();
                lab3.Run(inputPath, outputPath);
                break;
            default:
                console.WriteLine("Invalid lab specified. Use 'lab1', 'lab2', or 'lab3'.");
                break;
        }
    }
}

[Command(Name = "set-path", Description = "Set input/output path.")]
class SetPathCommand
{
    [Option("-p|--path", "Set LAB_PATH environment variable", CommandOptionType.SingleValue)]
    public string Path { get; set; }

    private void OnExecute(IConsole console)
    {
        if (!string.IsNullOrEmpty(Path))
        {
            Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
            console.WriteLine($"LAB_PATH set to: {Path}");
        }
        else
        {
            console.WriteLine("Please specify a path.");
        }
    }
}