using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Models.Dtos;
using LibraryManagement.ConsoleUI.Repository;
using System.Linq.Expressions;
using System.Net;

namespace LibraryManagement.ConsoleUI.Service;

public class BookService
{
    BookRepository bookRepository = new BookRepository(); //Methodalarda bookrepository kullanabilmek için.
                                                          //Verilerimeize de ulaşabilmek adına

    public void GetAll()
    {
        List<Book> books = bookRepository.GetAll();
        foreach (Book item in books)
        {
            Console.WriteLine(item);
        }
    }

    public void GetById(int id)
    {
        Book? book = bookRepository.GetById(id);
        if (book == null)
        {
            Console.WriteLine($"Aradığınız Id ait bir kitap bulunamadı: {id}");
            return;
        }
        Console.WriteLine(book);
    }

    public void Add(Book book)
    {
        Book created = bookRepository.Add(book);
        Console.WriteLine("Kitap Eklendi");
    }

    public void Remove(int id)
    {
        Book deletedBook = bookRepository.Remove(id);
        if (deletedBook != null)
        {
            Console.WriteLine("Aradığınız kitap bulunamadı");
            return;
        }
        Console.WriteLine(deletedBook);
    }

    public void GetBookByISBN(string isbn)
    {
        Book? isbnBook = bookRepository.GetBookByISBN(isbn);
        if (isbnBook is null)
        {
            Console.WriteLine($"Aradığınız ISBN kitap bulunamadı: {isbn}");
            return;
        }
        Console.WriteLine(isbnBook);
    }
    public void GetAllBooksByPageSizeFİlter(int min, int max)
    {
        List<Book> books = bookRepository.GetAllBooksByPageSizeFilter(min, max);
        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }
    }

    public void GetAllBooksByTitleContains(string text)
    {
        List<Book> books = bookRepository.GetAllBooksByTitleContains(text);
        books.ForEach(book => Console.WriteLine(book));
        //foreach (Book book in books)
        //{
        //    Console.WriteLine(book);
        //}
    }

    public void GetAllBookOrderByTitle()
    {
        List<Book> books = bookRepository.GetAllBookOrderByTitle();
        books.ForEach(book => Console.WriteLine(book));
    }
    public void GetBookMaxPageSize()
    {
        Book max = bookRepository.GetBookMaxPageSize();
        Console.WriteLine(max);
    }
    public void GetBookMinPageSize()
    {
        Book min = bookRepository.GetBookMinPageSize();
        Console.WriteLine(min);
    }

    public void GetDetails()
    {
        List<BookDetailDto> books = bookRepository.GetDetails();
        foreach (BookDetailDto bookDetail in books) { Console.WriteLine(bookDetail); }

    }
    public void GetDetails2()
    {
        List<BookDetailDto> books = bookRepository.GetDetails2();
        foreach (BookDetailDto bookDetail in books) { Console.WriteLine(bookDetail); }
    }
}
