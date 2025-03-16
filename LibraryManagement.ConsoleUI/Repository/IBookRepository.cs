using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Models.Dtos;

namespace LibraryManagement.ConsoleUI.Repository;

//Bu classı miras alacak sınıflar kullanacaktır.
//Sadece metod imzası tutarız.
public interface IBookRepository : IGenericRepository<Book, Guid>
{
    List<Book> GetAllBooksByPageSizeFilter(int min, int max);
    double PageSizeTotalCalculator();
    List<Book> GetAllBooksByTitleContains(string text);
    Book? GetBookByISBN(string isbn);
    List<Book> GetAllBookOrderByTitle();
    List<Book> GetAllBookOrderByDescendingTitle();
    Book GetBookMaxPageSize();
    Book GetBookMinPageSize();
    List<BookDetailDto> GetDetails();
    List<BookDetailDto> GetAllAuthorAndBookDetails();
    List<BookDetailDto> GetAllDetailsByCategoryId(int categoryId);
    List<BookDetailDto> GetAllDetailsByCategoryId2(int categoryId);
    List<string> GetAllTitles();

}
