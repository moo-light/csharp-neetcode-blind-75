using System.Threading.Channels;

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        Dictionary<char, int> dict = new();
        foreach (char c in s)
        {
            bool check =
                dict.TryAdd(c, 1);
            if (!check)
            {
                dict[c]++;
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
    public List<List<string>> GroupAnagrams(string[] strs)
    {
        List<List<string>> res = new();
        bool[] checkeds = new bool[strs.Length];
        for (int i = 0; i < strs.Length; i++)
        {
            if (checkeds[i]) continue;

            var list = new List<string>
            {
                strs[i]
            };
            checkeds[i] = true;
            for (int j = i + 1; j < strs.Length; j++)
            {

                if (checkeds[j]) continue;
                if (IsAnagram(strs[i], strs[j]))
                {
                    list.Add(strs[j]);
                    checkeds[j] = true;
                }

            }
            if (list.Count > 0)
                res.Add(list);
        }
        return res;
    }

    public static void Main()
    {
        var s = new Solution();
        var res = s.GroupAnagrams(
            new string[] { "act", "pots", "tops", "cat", "stop", "hat" }
        );
        Action<string> action = (x) => Console.Write($"{x} ");
        res.ForEach(x =>
        {
            x.ForEach(action);
            Console.WriteLine();
        });
    }
}
