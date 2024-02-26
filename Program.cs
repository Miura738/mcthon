
using mcthon.compiler;
using mcthon.run;
class Program
{
    public static Version version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
    public static string appName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

    static void Main(string[] args)
    {
        Application.Run(args);
    }
    
}