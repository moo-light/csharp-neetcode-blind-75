public class Solution
{
    public string MinWindow(string s, string t)
    {
        Func<int, int, bool> test = (int l, int r) =>
        {
            int i = 0;
            var dic = t.ToList();
            for (i = l; i <= r; i++)
            {
                if (dic.Contains(s[i]))
                    dic.Remove(s[i]);
            }
            return dic.Count == 0;
        };

        var result = "";
        var l = 0;
        var r = 0;

        for (r = 0; r < s.Length; r++)
        {
            while (test(l, r))
            {
                string subString = s.Substring(l, r - l + 1);
                if (result == "" || result.Length > subString.Length) result = subString;
                l++;
            }
        }
        Console.WriteLine(result);
        return result;
    }
    public static void Main(string[] args)
    {
        var so = new Solution();
        so.MinWindow("OUZODYXAZ", "XYZ");
        so.MinWindow("ASDSADSADSDSADASDSADASDASDDFASCAX", " ");
        so.MinWindow("XYZ", "XYZ");
        so.MinWindow("X", "XY");
    }
}

