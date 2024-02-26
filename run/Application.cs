namespace mcthon.run;

public class Application
{
    public static void Run(string[] args)
    {

        string app = "help";
        if (args.Length >= 1)
        {
            app = args[0];
        }
        
        switch (app)
        {
            case "build":
                
                compiler.Build.Run(args);
                break;
            
            
            case "version":
            case "-v":
            case "-version":
            case "-V":
                Help.Version();
                break;
                
            default:
                Help.Log();
                break;
            
        }
                
        
        return;
    }
}