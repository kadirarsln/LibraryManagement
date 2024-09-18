using LibraryManagement.ConsoleUI.Models;
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
}
