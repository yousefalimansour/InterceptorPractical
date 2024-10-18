﻿
using IterceptorPractical.Data;

namespace C01.Interceptors.Helpers
{
    public static class DatabaseHelper
    {
        public static void RecreateCleanDatabase()
        {
            using var context = new AppDBContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void PopulateDatabase()
        {
            using (var context = new AppDBContext())
            {
                context.Books.AddRange(
                     new Book
                     {
                         Id = 1,
                         Author = "Eric Evans",
                         Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                     },
                          new Book
                          {
                              Id = 2,
                              Author = "Eric Evans",
                              Title = "Domain-Driven Design Reference: Definitions and Pattern Summaries"
                          },
                          new Book
                          {
                              Id = 3,
                              Author = "John Skeet",
                              Title = "C# In Depth"
                          },
                          new Book
                          {
                              Id = 4,
                              Author = "John Skeet",
                              Title = "Real world functional programming"
                          },
                          new Book
                          {
                              Id = 5,
                              Title = "Grokking Algorithms",
                              Author = "Aditya Bhargava"
                          });
                context.SaveChanges();
            }
        }

        public static void ShowBooks()
        {
            Console.WriteLine();
            Console.WriteLine("Books");
            Console.WriteLine("-----");
            var context = new AppDBContext();
            foreach (var book in context.Books)
            {

                var bookTitle = $"{(book.Title.Length >= 11 ? book.Title.Substring(0, 11) : book.Title)}...";

                Console.WriteLine($"Id: {book.Id}, Title: {bookTitle}, Author: {book.Author,20}, IsDeleted: {book.IsDeleted} ");
            }
        }
    }
}
