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
                
                Console.WriteLine("Start build");
                break;
            
            
            default:
                
                Help.Log();
                break;
            
        }
                
        
        return;
    }
}