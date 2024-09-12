
public class Solution
{
    public bool IsPalindrome(string s)
    {
        var newStr = ClearString(s.ToUpper()) ;
        string revStr = ReverseString(newStr);

        return revStr.Equals(newStr);
    }

    private string ReverseString(string s)
    {
        var newStr = "";
        for (int i = 0; i < s.Length; i++)
        {
            newStr = s[i] + newStr;
        }
        Console.WriteLine(newStr);
        return newStr;
    }

    // only accept Upper Case
    public string ClearString(string s)
    {
        string newStr = "";
        for (int i = 0; i < s.Length; i++)
        {
            int check = s[i] - 'A';
            if (check <= 26 && check >= 0) newStr += s[i];
            check = s[i] - '0';
            if (check <= 9 && check >= 0) newStr += s[i];
        }
        Console.WriteLine(newStr);

        return newStr;
    }
    public static void Main()
    {
        var so = new Solution();
        Console.WriteLine( so.IsPalindrome("A man, a plan, a canal: Panama"));
        Console.WriteLine( so.IsPalindrome( "Was it a car or a cat I saw?"));
    }
}

