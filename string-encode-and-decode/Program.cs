public class Solution
{
    private const char SEPERATOR = '|';

    public string Encode(IList<string> strs)
    {
        var result = string.Empty;
        foreach (var item in strs)
        {
            result += item + SEPERATOR;
        }

        return result;
    }

    public List<string> Decode(string s)
    {
        var result = new List<string>();
        var str = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == SEPERATOR)
            {
                result.Add(str); 
                str = "";
            }else
            str += s[i];
        }
        return result;
    }
    public static void Main()
    {
        var sol = new Solution();
        foreach (var item in sol.Decode(sol.Encode(new string[] { "we", "say", ":", "yes" })))
        {
            Console.WriteLine(item);
        }
    }
}
