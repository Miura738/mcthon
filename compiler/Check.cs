using System.Text.RegularExpressions;

namespace mcthon.compiler;

public class Check
{
    public static bool IsQuotes(string value, out string? str)
    {
        
        bool surroundedBySingleQuotes = Regex.IsMatch(value, "^'.*?'$");
        bool surroundedByDoubleQuotes = Regex.IsMatch(value, "^\".*?\"$");

        if (surroundedBySingleQuotes || surroundedByDoubleQuotes)
        {
            char[] charsToTrim = ['"', '\''];
            str = value.Trim(charsToTrim);
            return true;
        };

        str = null;
        return false;

    }
}