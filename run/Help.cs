using System.Text.Json;

namespace mcthon.run;

public class Help
{
    public static void Log()
    {
        
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, "package.json");

        string projectName = "no active project";
        
        if (File.Exists(filePath))
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                JsonDocument jsonDocument = JsonDocument.Parse(jsonString);

                // 对 JSON 数据进行操作，例如获取属性值
                JsonElement root = jsonDocument.RootElement;
                string value = root.GetProperty("name").GetString() ?? throw new InvalidOperationException();
                projectName = $"active project: {value}";
            }
            catch
            {
                projectName = "project error";
            }
        }
        
        
        Console.WriteLine("{0} {1} - {2}\n",Program.appName,Program.version,projectName);
        Console.WriteLine("Usage:\n  mcthon <command> [options] [args]\n");
        Console.WriteLine("Available commands:");
        Console.WriteLine("  build    build my file to .mcfunction");
        Console.WriteLine("  package  package mcthon active project");
        Console.WriteLine("  help     log command help");
        Console.WriteLine("  version  get mcthon version");

    }

    public static void Version()
    {
        Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
        string appName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        
        Console.Write("{0} {1}",appName,version);

    }
}