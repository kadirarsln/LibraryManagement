namespace LibraryManagement.ConsoleUI.Models.Dtos;

public record BookDetailDto(

        Guid Id,
        string CategoryName,
        string AuthorName,
        string AuthorSurname,
        string Tittle,
        string Description,
        int PageSize,
        string PublishDate,
        string ISBN
    );
