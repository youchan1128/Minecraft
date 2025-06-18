namespace Programming01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Add:" + Add(10, 20));
            ValMain();
        }
        static int Add(int a, int b)
        {
            int c = a + b;
            return c;
        }

        static void ValMain()
        {
            int nScore = 0;
            float fRat = 1.0f / 4.0f;
            Console.WriteLine("Score: " + nScore);
            Console.WriteLine("Rat: " + fRat);
        }
    }
}
