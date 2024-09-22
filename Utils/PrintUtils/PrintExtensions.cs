public static class PrintExtensions
{
    public static void Print(this object obj) 
    {
        if (obj is null) Console.WriteLine(obj);
        if (obj is IEnumerable<object>)
        {
            foreach (object item in obj as IEnumerable<object>)
            {
                Print(item);
            }
            Console.WriteLine();
            return;
        }
        Console.WriteLine(obj);
    }
}