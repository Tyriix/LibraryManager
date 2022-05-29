using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BookServices;
using LibraryManager.EntityFramework.Services;
using System;

namespace Tests
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            var test = new Testbook();
            Console.WriteLine(test.Test().Result);
        }
        
    }
}
