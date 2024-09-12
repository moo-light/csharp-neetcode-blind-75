using System.Net.Http.Headers;


bool IsValid(string s)
{
    string OB = "{[(";
    string CB = "}])";
    bool result = true;
    var st = new Stack<char>();
    Console.WriteLine(s);

    for (int i = 0; i < s.Length; i++)
    {
        // {[(
        if (OB.Contains(s[i]))
        {
            st.Push(s[i]);
            continue;
        }
        // }])
        if (CB.Contains(s[i]) && st.Count > 0)
        {
            var peek = st.Peek();
            Console.WriteLine(peek +"" + s[i]);
            if ( OB.IndexOf(peek) == CB.IndexOf(s[i]))
            {
                st.Pop();
                continue;
            }
        }
        result = false;
        break;
    }
    if (st.Count != 0) result = false;
    Console.WriteLine(result);
    return result;
}

//IsValid("");
//IsValid("}");
IsValid("[(])");
IsValid("{()}");
IsValid("{())}");
IsValid("}{())}");
IsValid("{()}{()");
IsValid("{()}()");
IsValid("{({})}({})");