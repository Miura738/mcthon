namespace mcthon.run;

public class Help
{
    public static void Log()
    {
        Console.WriteLine("____Help____");
        Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
        Console.WriteLine("版本号：" + version);

        // 获取当前程序的名称
        string appName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        Console.WriteLine("程序名称：" + appName);
    }
}