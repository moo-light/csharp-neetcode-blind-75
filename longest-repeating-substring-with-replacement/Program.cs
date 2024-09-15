// find the most length of same character by replacing at most k element 
int CharacterReplacement(string s, int k)
{
    var charsCount = new int[26];
    var curCharacterMaxCount = 0;
    int maxLength = 0, l = 0;
    for (var r = 0; r < s.Length; r++)
    {
        charsCount[s[r] - 'A']++;

        curCharacterMaxCount = charsCount.Max(x => x);
        var mostChangesAllow = r - l + 1 - curCharacterMaxCount;
        if (mostChangesAllow > k)
        {
            charsCount[s[l] - 'A']--;
            l++; 
        }
        maxLength = Math.Max(r-l+1, maxLength);

        //printing
        for (global::System.Int32 i = 0; i < charsCount.Length; i++)
        {
            if (charsCount[i] > 0)
                Console.Write((char)(i + 'A') + "-" + charsCount[i] + " ");
        }
        Console.WriteLine();

        for (global::System.Int32 j = l; j <= r; j++)
        {
            Console.Write(s[j]);
        }
        Console.WriteLine();
    }

    return maxLength;
}
// ABBCDEEE 2
// ABB -> AAA
// ABBC x
// BBCD -> BBBB
// CDEE -> EEEE
// CDEEE

Console.WriteLine(CharacterReplacement("XYYX", 2));
Console.WriteLine(CharacterReplacement("AAABABB", 1));
Console.WriteLine(CharacterReplacement("XYYXSAAADDAWREE", 2));
