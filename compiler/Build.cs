using System.Text.RegularExpressions;

namespace mcthon.compiler;

public class Build
{
    public static void Run(string[] args)
    {
        if (args.Length == 2)
        {
            string file = args[1];
            string OutFile = file.EndsWith(".my") ? file.Replace(".my", ".mcfunction") : $"{file}.mcfunction";
            if (!file.EndsWith(".my")) file = $"{file}.my";
            
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, file);
            string OutfilePath = Path.Combine(currentDirectory, OutFile);
            
            try
            {
                StreamReader sr = new StreamReader(filePath);
                StreamWriter writer = new StreamWriter(OutfilePath);
                string line;

                // 逐行读取文件内容
                while ((line = sr.ReadLine()) != null)
                {
                    string result;
                    
                    // 定义正则表达式模式，用于匹配 Print.title("...") 格式的字符串
                    string printTitle = @"Print\.title\((.*)\)";

                    Match printTitleMatch = Regex.Match(line, printTitle);

                    if (printTitleMatch.Success) result = Print.Title.Run(printTitleMatch,filePath);
                    else result = $"\n{line}";
                    
                    Console.Write(result);
                    writer.WriteLine(result);
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            
        }
        else
        {
            Console.WriteLine("{0} {1} - {2}\n",Program.appName,Program.version,"Compiler");

            Console.WriteLine("Usage:\n  mcthon build [path]");
        }
    }
}