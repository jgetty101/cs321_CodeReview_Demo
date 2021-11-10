using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Code_Review
{
    class Book
    {
       /* private string title;
        private string iSBN;
        private string author;
        private string date;
        private bool isIssued;*/

        public string Title { get; set; }
        public String ISBN { get; set; }
        public string Author { get; set; }
        public String Date { get; set; }
        public bool IsIssued { get; set; }

        public Book(string title, string iSBN, string author, string date, bool isIssued)
        {
            this.Title = title;
            this.ISBN = iSBN;
            this.Author = author;
            this.Date = date;
            this.IsIssued = isIssued;
        }
    }

    class Library
    {
        private List<Book> listOfBooks;
        public Library()
        {
            listOfBooks = new List<Book>
            {
                new Book("Dune", "A1B12CS", "Frank Herbert", "April 10, 1925", false),
                new Book("The Great Gatsby", "AJDJ38B3", " F. Scott Fitzgerald", "March 25, 2016", false),
                new Book("The Handmaid's Tale", "KD83EIU", "Margaret Atwood", "1986", false),
                new Book("Beloved", "JDJFF83BF", "Toni Morrison", "Septmeber 24, 2000", false),
            }; 
        }

        public void AddBook(string title, string iSBN, string author, string date)
        {
            Book newBook = new Book(title, iSBN, author, date, false);
        }

        public void issueBook(string isbn)
        {
            bool found = false;

            // Checking if the book is present in the list?
            foreach (Book book in listOfBooks)
            {
                if (String.Equals(book.ISBN, isbn))
                {
                    found = true;
                }
            }

            // If book is found, update the issued status.
            if(found == true)
            {
                foreach (Book book in listOfBooks)
                {
                    if (String.Equals(book.ISBN, isbn))
                    {
                        if (book.IsIssued == false)
                        {
                            book.IsIssued = true;
                        }
                    }
                }
            }
        }

        public void returnBook(string isbn)
        {
            bool found = false;

            // Checking if the book is present in the list?
            foreach (Book book in listOfBooks)
            {
                if (String.Equals(book.ISBN, isbn))
                {
                    found = true;
                }
            }

            // If book is found, update the issued status.
            if (found == true)
            {
                foreach (Book book in listOfBooks)
                {
                    if (String.Equals(book.ISBN, isbn))
                    {
                        if (book.IsIssued == true)
                        {
                            book.IsIssued = false;
                        }
                    }
                }
            }
        }

        public void displayBookInfo(string info)
        {
            foreach (Book book in listOfBooks)
            {
                if (String.Equals(book.ISBN, info) || String.Equals(book.Title, info))
                {
                    Console.WriteLine("\nTitle: " + book.Title);
                    Console.WriteLine("ISBN: " + book.ISBN);
                    Console.WriteLine("Author: " + book.Author);
                    Console.WriteLine("Date: " + book.Date);
                    Console.WriteLine("Is issued: " + book.IsIssued);
                    Console.WriteLine("\n");
                }
            }
        }

        public void displayAllBooks()
        {
            foreach (Book book in listOfBooks)
            {
                
                Console.WriteLine("\nTitle: " + book.Title);
                Console.WriteLine("ISBN: " + book.ISBN);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine("Date: " + book.Date);
                Console.WriteLine("Is issued: " + book.IsIssued);
                Console.WriteLine("\n");
                
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Welcome to the Library*****\n\n");
            Library library = new Library();
            Console.WriteLine("Menu: \n");
            Console.WriteLine("1. Display all the books.\n");
            Console.WriteLine("2. Issue book.\n");
            Console.WriteLine("3. Add Book. \n");
            Console.WriteLine("4. Return Book. \n");
            Console.WriteLine("5. Display book Info. \n ");
            Console.WriteLine("6. Quit.");
            Int32 choice;
            do
            {
                String input, isbn;
                Console.WriteLine("\nChoice: ");
                input = Console.ReadLine();
                choice = Convert.ToInt32(input);
                switch (choice)
                {
                    case 1:
                        library.displayAllBooks();
                        break;
                    case 2:
                        Console.WriteLine("Please enter the ISBN: ");
                        isbn = Console.ReadLine();
                        library.issueBook(isbn);
                        break;
                    case 3:
                        Console.WriteLine("\nPlease enter the following info about the book:");
                        Console.WriteLine("\nTitle: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("\nISBN: ");
                        isbn = Console.ReadLine();
                        Console.WriteLine("\nAuthor: ");
                        string author = Console.ReadLine();
                        Console.WriteLine("\nDate: ");
                        string date = Console.ReadLine();
                        library.AddBook(title, isbn, author, date);
                        break;
                    case 4:
                        Console.WriteLine("Please enter the ISBN: ");
                        isbn = Console.ReadLine();
                        library.issueBook(isbn);
                        library.issueBook(isbn);
                        break;
                    case 5:
                        Console.WriteLine("Please enter the Title/ISBN of the book: ");
                        string info = Console.ReadLine();
                        library.displayBookInfo(info);
                        break;
                }
            } while (choice != 6);
        }
    }
}
