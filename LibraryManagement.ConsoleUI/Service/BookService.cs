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

    public void GetById(Guid id)
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
        BookIdBusinessRules(book.Id);
        BookISBNBusinessRules(book.ISBN);

        Book crreated = bookRepository.Add(book);
        Console.WriteLine("Kitap Eklendi");
    }

    private void BookISBNBusinessRules(string ıSBN)
    {
        throw new NotImplementedException();
    }

    public void Remove(Guid id)
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

    public void GetAllBookOrderByDescendingTitle()
    {
        List<Book> books = bookRepository.GetAllBookOrderByDescendingTitle();
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
    //public void GetDetails2()
    //{
    //    List<BookDetailDto> books = bookRepository.GetDetails2();
    //    foreach (BookDetailDto bookDetail in books) { Console.WriteLine(bookDetail); }
    //}

    public void GetAllAuthorAndBookDetails()
    {
        List<BookDetailDto> detailDtos = bookRepository.GetAllAuthorAndBookDetails();
        detailDtos.ForEach(bookDetail => Console.WriteLine(bookDetail));
    }

    public void GetAllDetailsByCategoryId(int categoryId)
    {
        List<BookDetailDto> detailDtos = bookRepository.GetAllDetailsByCategoryId(categoryId);
        detailDtos.ForEach(bookDetail => Console.WriteLine(bookDetail));
    }
    public void GetAllDetailsByCategoryId2(int categoryId)
    {
        List<BookDetailDto> detailDtos = bookRepository.GetAllDetailsByCategoryId2(categoryId);
        detailDtos.ForEach(bookDetail => Console.WriteLine(bookDetail));
    }

    private void BookIdBusinessRules(Guid id)
    {
        Book? getByIdBook = bookRepository.GetById(id);
        if (getByIdBook != null)
        {
            Console.WriteLine($"Girmiş olduğunuz kitabın Id alanı benzersiz olmalıdır: {id}");
            return;
        }
    }
    private void BookISBNBusinessRules(Guid isbn)
    {
        Book? getByIdBook = bookRepository.GetById(isbn);
        if (getByIdBook != null)
        {
            Console.WriteLine($"Girmiş olduğunuz kitabın Id alanı benzersiz olmalıdır: {isbn}");
            return;
        }
    }
}
