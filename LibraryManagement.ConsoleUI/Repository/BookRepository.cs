using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Models.Dtos;
using LibraryManagement.ConsoleUI.Service;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        private List<Book> books;
        private List<Category> categories;
        private List<Author> authors;
        private List<Member> members;


        public BookRepository()
        {
            books = Books();
            categories = Categories();
            authors = Authors();
            //members = Members();
            //Base repositoryden gelmektedir.
        }


        //LINQ = Language Integrated Query 
        public List<Book> GetAll()
        {
            return books;
        }

        public List<Book> GetAllBooksByPageSizeFilter(int min, int max)
        {
            //---------GELENEKSEL YÖNTEM-----------------
            //List<Book> filteredBooks = new List<Book>();

            //foreach (Book book in books)
            //{
            //    if (book.PageSize <= max && book.PageSize >= min)
            //    {
            //        filteredBooks.Add(book);
            //    }
            //}
            //return filteredBooks;

            //**LINQ İlk yöntem (en geleneksel). ToList methodunda DB Connections kesilmektedir. Joinlerde kullanırız.

            //List<Book> result = (from b in books
            //                     where b.PageSize <= max && b.PageSize >= min
            //                     select b).ToList();
            //return result;

            //Where koşulundan sonra IEnumerable ise To... methodlarını kullanacaksak Where.
            //List<Book> result =books.Where(b=>b.PageSize <= max && b.PageSize >= min).ToList();

            //FindAll(); direkt liste dönmektedir. Kesinlikle liste döneceksek kullanırız. Daha performanslıdır.
            List<Book> result = books.FindAll(b => b.PageSize <= max && b.PageSize >= min);
            return result;
        }

        public double PageSizeTotalCalculator()
        {
            double total = books.Sum(book => book.PageSize);
            return total;
        }

        public List<Book> GetAllBooksByTitleContains(string text)
        {
            //List<Book> filteredBooksText = new List<Book>();
            //foreach (Book book in books)
            //{
            //    if (book.Tittle.Contains(text, StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        filteredBooksText.Add(book);
            //    }
            //}
            //return filteredBooksText;

            //List<Book> result = books.Where(b => b.Tittle.Contains(text, StringComparison.InvariantCultureIgnoreCase)).ToList();
            List<Book> result = books.FindAll(b => b.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase));
            return result;
        }

        //Null gelebilir. Önden uyarıyoruz.
        public Book? GetBookByISBN(string isbn)
        {

            //Book? book1 = null;  //new ile tanımlarsak Bütün değerlerini girmemiz gerekir.

            //foreach (Book item in books)
            //{
            //    if (item.ISBN == isbn)
            //    {
            //        book1 = item;
            //    }
            //}

            ////return book1 is null ? null : book1;

            ///* return book1 ?? book1;*/// varsa döner ?? varsa
            //if (book1 == null)
            //{
            //    return null;
            //}
            //return book1;

            //Book? book = (from b in books where b.ISBN == isbn select b).FirstOrDefault();      //First kullanırsak kesinlikle bir eleman gerekmektedir.


            //Book book = books.Where(x => x.ISBN == isbn).SingleOrDefault();  //Single ve Firstte ısbn kontrolünde 1tane Uniqe değer varsa Single.

            Book book = books.SingleOrDefault(x => x.ISBN == isbn);            //Where koşulu olmadan da yazabiliriz.
            return book;

        }

        //Küçükten Büyüğe Doğru sayı olarak A -----> Z Harf olarak.
        public List<Book> GetAllBookOrderByTitle()
        {
            List<Book> orderedBooks = books.OrderBy(b => b.Title).ToList();
            return orderedBooks;
        }

        //Büyükten Küçüğe Doğru sayı olarak Z-----> A Harf olarak.
        public List<Book> GetAllBookOrderByDescendingTitle()
        {
            List<Book> orderedBooks = books.OrderByDescending(b => b.Title).ToList();
            return orderedBooks;
        }

        public Book GetBookMaxPageSize()
        {
            Book max = books.OrderByDescending(x => x.PageSize).FirstOrDefault();   //Azalan Sırada Büyükten Küçüğe
            return max;
        }
        public Book GetBookMinPageSize()
        {
            Book min = books.OrderBy(x => x.PageSize).FirstOrDefault();
            return min;
        }

        public Book Add(Book created)
        {
            books.Add(created);
            return created;
        }

        public Book? GetById(Guid id)
        {
            Book? book1 = null;
            foreach (Book item in books)
            {
                if (item.Id == id)
                {
                    book1 = item;
                }
            }
            if (book1 == null)
            {
                return null;
            }
            return book1;
        }

        public Book? Remove(Guid id)
        {
            Book deletedBook = GetById(id);
            if (deletedBook != null)
            {
                return null;
            }
            books.Remove(deletedBook);
            return deletedBook;
        }

        public List<BookDetailDto> GetDetails()
        {
            var result =
                from book in books
                join category in categories
                on book.CategoryId equals category.Id
                join author in authors
                on book.AuthorId equals author.Id
                select new BookDetailDto(
                    Id: book.Id,
                    CategoryName: category.Name,
                    AuthorName: author.Name,
                    AuthorSurname: author.Surname,
                    Tittle: book.Title,
                    Description: book.Description,
                    PageSize: book.PageSize,
                    PublishDate: book.PublishDate,
                    ISBN: book.ISBN
                    );
            return result.ToList();
        }

        //2 Den fazla tablomuz varsa Lambda yöntemi yetersiz kalmaktadır.
        //public List<BookDetailDto> GetDetails2()
        //{
        //    List<BookDetailDto> details =
        //        books.Join(categories,

        //        b => b.CategoryId,
        //        c => c.Id,
        //        (book, category) => new BookDetailDto(
        //            Id: book.Id,
        //            CategoryName: category.Name,
        //            "",
        //            Tittle: book.Tittle,
        //            Description: book.Description,
        //            PageSize: book.PageSize,
        //            PublishDate: book.PublishDate,
        //            ISBN: book.ISBN

        //            )
        //        ).ToList();
        //    return details;
        //}

        public List<BookDetailDto> GetAllAuthorAndBookDetails()
        {
            var result =
                from book in books
                join category in categories on book.CategoryId equals category.Id
                join author in authors on book.AuthorId equals author.Id

                select new BookDetailDto(
                    Id: book.Id,
                    CategoryName: category.Name,
                    AuthorName: author.Name,
                    AuthorSurname: author.Surname,
                    Tittle: book.Title,
                    Description: book.Description,
                    PageSize: book.PageSize,
                    PublishDate: book.PublishDate,
                    ISBN: book.ISBN
                    );
            return result.ToList();
        }

        public List<BookDetailDto> GetAllDetailsByCategoryId(int categoryId)
        {
            var result =
                from book in books
                where book.CategoryId == categoryId
                join category in categories on book.CategoryId equals category.Id
                join author in authors on book.AuthorId equals author.Id

                select new BookDetailDto(
                    Id: book.Id,
                    CategoryName: category.Name,
                    AuthorName: author.Name,
                    AuthorSurname: author.Surname,
                    Tittle: book.Title,
                    Description: book.Description,
                    PageSize: book.PageSize,
                    PublishDate: book.PublishDate,
                    ISBN: book.ISBN
                    );
            return result.ToList();
        }

        public List<BookDetailDto> GetAllDetailsByCategoryId2(int categoryId)
        {
            List<BookDetailDto> details =
                books.Where(x => x.CategoryId == categoryId).Join(categories,

                b => b.CategoryId,
                c => c.Id,
                (book, category) => new BookDetailDto(
                    Id: book.Id,
                    CategoryName: category.Name,
                    "",
                    "",
                    Tittle: book.Title,
                    Description: book.Description,
                    PageSize: book.PageSize,
                    PublishDate: book.PublishDate,
                    ISBN: book.ISBN

                    )
                ).ToList();
            return details;
        }

        public List<string> GetAllTitles()
        {
            List<string> titles = books.Select(x => x.Title).ToList();
            return titles;
        }


        public Book? Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
