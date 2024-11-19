using System.Text;
using ClassLib.Lab1;
using ClassLib.Lab2;
using ClassLib.Lab3;
using McMaster.Extensions.CommandLineUtils;

const string defaultInputFileName = "INPUT.TXT";
const string defaultOutputFileName = "OUTPUT.TXT";

Console.OutputEncoding = Encoding.Unicode;

var app = new CommandLineApplication
{
    Name = "Y_Andreieva",
    Description = "Lab Work 4",
};

app.HelpOption();

app.Command("version", versionCmd =>
{
    versionCmd.Description = "Show version";
    versionCmd.OnExecute(() =>
    {
        Console.WriteLine("Author: Yuliia Andreieva, IPZ-31");
        Console.WriteLine("Version: 1.0.0");
    });
});

app.Command("set-path", setPath =>
{
    setPath.Description = "Set path to folder with input and output files";
    var path = setPath.Option("-p|--path", "Path to folder", CommandOptionType.SingleValue).IsRequired();
    setPath.OnExecute(() =>
    {
        if (OperatingSystem.IsWindows())
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path.Value(), EnvironmentVariableTarget.User);
        }
        else
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path.Value());
        }
    });
});

app.Command("run", run =>
{
    run.Description = "Run lab";
    run.OnExecute(() =>
    {
        Console.WriteLine("Specify the lab to run");
        run.ShowHelp();
    });

    var input = run.Option("-i|--input", "Input file path", CommandOptionType.SingleValue, true);
    var output = run.Option("-o|--output", "Output file path", CommandOptionType.SingleValue, true);

    run.Command("lab1", lab1 =>
    {
        lab1.Description = "Run lab 1";
        lab1.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, defaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, defaultOutputFileName);
            Lab1Runner.Run(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

    run.Command("lab2", lab2 =>
    {
        lab2.Description = "Run lab 2";
        lab2.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, defaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, defaultOutputFileName);
            Lab2Runner.Run(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

    run.Command("lab3", lab3 =>
    {
        lab3.Description = "Run lab 3";
        lab3.OnExecute(() =>
        {
            var folderPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            var inputFilePath = input.HasValue() ? input.Value() : Path.Combine(folderPath, defaultInputFileName);
            var outputFilePath = output.HasValue() ? output.Value() : Path.Combine(folderPath, defaultOutputFileName);
            Lab3Runner.Run(inputFilePath ?? "", outputFilePath ?? "");
        });
    });

});

app.OnExecute(() =>
{
    Console.WriteLine("Specify a subcommand");
    app.ShowHelp();
});

try
{
    app.Execute(args);
}
catch (Exception e)
{
    Console.WriteLine($"An error occurred: {e.Message}");
}