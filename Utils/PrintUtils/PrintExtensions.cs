using System.Collections;

public static class PrintExtensions
{
    public static void Print(this object obj,bool wl = true) 
    {
        if (obj is null) Console.WriteLine(obj);
        if (obj is (IEnumerable or Array) )
        {
            foreach (object item in (obj as IEnumerable))
            {
                Print(item,false);
            }
            Console.WriteLine();
            return;
        }
        Console.Write(obj+" ");
        if (wl) Console.WriteLine();
    }
}