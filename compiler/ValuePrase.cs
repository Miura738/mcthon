using System.Text.RegularExpressions;

namespace mcthon.compiler;

using System;
using System.Collections.Generic;

public static class ValuePrase
{
    public static Dictionary<string, string> Run(List<string> keys, string valuesStr, string filePath)
    {
        List<string> values = new List<string>();
        string pattern = "(?<=^|,)(\"(?:[^\"]|\"\")*\"|[^,]*)";

        MatchCollection matches = Regex.Matches(valuesStr, pattern);
        foreach (Match match in matches) values.Add(match.Value.Trim());

        Dictionary<string, string> keyValuePairs = ParseStringList(keys, values, filePath);

        return keyValuePairs;
    }

    static Dictionary<string, string> ParseStringList(List<string> keys, List<string> values, string filePath)
    {
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

        
        KeyValueChecker checker = new KeyValueChecker();
        string bKey, bValue;
        
        foreach (string value in values)
        {
            if (Check.IsQuotes(value, out bValue))
            {
                if (keys.Count >= 1)
                {
                    keyValuePairs[keys[0]] = value;
                    keys.Remove(keys[0]);
                }
                else
                {
                    Console.WriteLine($"Error: in {filePath}");
                    Environment.Exit(0);
                }
            }
            else if (checker.IsKeyValueFormat(value,out bKey,out bValue))
            {
                if (keys.Contains(bKey))
                {
                    keyValuePairs[bKey] = bValue;
                    keys.Remove(bKey);
                }
                else
                {
                    Console.WriteLine($"Error: in {filePath}");
                    Environment.Exit(0);
                }
                
               
            }
            else
            {
                if (keys.Count >= 1)
                {
                    keyValuePairs[keys[0]] = value;
                    keys.Remove(keys[0]);
                }
                else
                {
                    Console.WriteLine($"Error: in {filePath}");
                    Environment.Exit(0);
                }
                
            }
            
            
        }

        return keyValuePairs;
    }
    
    
    

}

public class KeyValueChecker
{
    public bool IsKeyValueFormat(string input, out string key, out string value)
    {
        // 使用正则表达式匹配 key=value 格式
        Match match = Regex.Match(input, @"^([^=]+)=([^=]+)$");
        
        if (match.Success)
        {
            key = match.Groups[1].Value;
            value = match.Groups[2].Value;
            
            // 检查引号情况，如果=在引号包括的单引号里则不匹配
            if (value.Contains("'") && value.IndexOf("'") < value.LastIndexOf("'"))
            {
                return false;
            }
            
            return true;
        }
        
        key = null;
        value = null;
        return false;
    }
}
