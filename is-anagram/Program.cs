using System.Reflection;

public class Solution
{

    /**
        Example 1:

        Input: s = "racecar", t = "carrace"

        Output: true
        Example 2:

        Input: s = "jar", t = "jam"

        Output: false

        An anagram is a string that contains the exact same characters as another string, but the order of the characters can be different.
    */
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        Dictionary<char, int> dict = [];
        foreach (char c in s)
        {
            bool check = dict.ContainsKey(c);
            if (check)
            {
                dict[c]++;
            }
            else
            {
                dict.Add(c, 1);
            }
        }
        foreach (var c in t)
        {
            bool check = dict.ContainsKey(c);
            if (!check) return false;
            dict[c]--;
            if (dict[c] == 0) dict.Remove(c);
        }
        return dict.Count == 0;
    }

    public static Solution sol = new Solution();
    public static void MyPrinter(MethodInfo func, params object[] inputs)
    {
        Console.Write($"Input: ");
        foreach (var inp in inputs)
        {
            if (inp is Array)
            {
                foreach (var item in (inp as Array))
                {
                    Console.Write(item);
                }
            }
            Console.Write(inp + " ");
        }
        Console.WriteLine();

        var @res = func.Invoke(sol, inputs);
        Console.WriteLine($"Output: {@res}\n");
    }

    public static void Main()
    {
        var s = "racecar";
        var t = "carrace";
        
        var func = sol.IsAnagram;
        var methodInfo = func.GetMethodInfo();

        MyPrinter(methodInfo, s, t);
        MyPrinter(methodInfo, "jar", "jam");
        MyPrinter(methodInfo, "abacaddaaae", "eaaaddacaba");
    }
}
