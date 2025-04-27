using System.Diagnostics;
using System.Xml.Linq;
using static Task12_1.Program;

namespace Task12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book<string, int>[] books1 = new Book<string, int>[]
                {
                    new Book<string, int>("abcde", 1873,"Война и мир","Л.Н. Толстой"),
                    new Book<string, int>("F-1234", 1866,"Преступление и наказание","Ф.М. Достоевский")
                };

            Book<int, string>[] books2 = new Book<int, string>[]
                {
                    new Book<int, string>(42,"1873-1884","Война и мир","Л.Н. Толстой"),
                    new Book<int, string>(444,"1866-1885","Преступление и наказание","Ф.М. Достоевский")
                };

            var book1 = FindBook(books1, "F-1234");
            if (book1 == null)
            {
                Console.WriteLine("Книга не найдена");
            }
            else
            {
                Console.WriteLine(book1);
            }

            var book2 = FindBook(books2, 42);
            if (book2 == null)
            {
                Console.WriteLine("Книга не найдена");
            }
            else
            {
                Console.WriteLine(book2);
            }

            Console.ReadLine();
        }

        public static Book<T, U> FindBook<T, U>(Book<T, U>[] books, T code)
        {
            foreach (Book<T, U> book in books)
            {
                if (book.Code.Equals(code))
                    return book;
            }
            return null;
        }

        public class Book<T, U>
        {
            public T Code { get; set; }
            public U PublicationYear { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public Book(T _code, U _PublicationYear, string _Title, string _Author)
            {
                Code = _code;
                PublicationYear = _PublicationYear;
                Title = _Title;
                Author = _Author;
            }
            public override string ToString()
                => $"Код: {Code} ({typeof(T).Name}), Название: {Title}, Автор: {Author}, Год:{PublicationYear}({typeof(U).Name})";
        }
    }
}
