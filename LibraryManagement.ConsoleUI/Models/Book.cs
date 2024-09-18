namespace LibraryManagement.ConsoleUI.Models
{
    public record Book(
        int Id,
        string Tittle,
        string Description,
        int PageSize,
        string PublishDate,
        string ISBN);
}
