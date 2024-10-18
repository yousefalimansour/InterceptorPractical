using C01.Interceptors.Helpers;
using IterceptorPractical.Data;

namespace IterceptorPractical
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();

            Console.WriteLine();
            Console.WriteLine("Before Delete");
            DatabaseHelper.ShowBooks();

            using (var context = new AppDBContext())
            {
                var book = context.Books.First();
                context.Books.Remove(book);
                context.SaveChanges();
            }
            Console.WriteLine();
            Console.WriteLine("After Delete Book Id = '1'");

            DatabaseHelper.ShowBooks();

            Console.ReadKey();
        }
    }
}
