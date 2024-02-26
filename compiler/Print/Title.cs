
using System.Text.RegularExpressions;

namespace mcthon.compiler.Print;

public class Title
{

    
    public static string Run(Match args, string filePath)
    {
        string arg = args.Groups[1].Value;

        List<string> keys = new List<string> { "title", "target", "position" };

        Dictionary<string, string> result = ValuePrase.Run(keys, arg, filePath);

        string title, target, position;

        Check.IsQuotes(result["title"], out title);
        Check.IsQuotes(result["target"], out target);
        Check.IsQuotes(result["position"], out position);
        
        
        
       
        return $"\ntitle {target} {position} \"{title}\"";

    }
}