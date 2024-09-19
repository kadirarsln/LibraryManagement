using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Models.Dtos;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class BookRepository
    {
        List<Book> books = new List<Book>()
        {
new Book (1,1,"Germinal", "Kömür Madeni", 341,"2012 Mayıs", "9781234567897"),
new Book (2,1,"Suç ve Ceza", "Raskolnikov", 341,"2010 Haziran", "9781234567895"),
new Book (3,1,"Kumarbaz", "Bir Öğretmenin Hayatı", 210,"2009 Ocak", "9781234567892"),
new Book (4,2,"Araba Sevdası", "Araba ile alakası olmayan kitap", 180,"2000 Ocak", "9781234567838"),
new Book (5,2,"Ateşten Gömlek", "Kurtuluş Savaşını anlatan gitap", 120,"2001 Eylül", "9781234567834"),
new Book (6,2,"Kaşağı", "Okunmaması gereken bir kitap", 95,"1993 Ocak", "9781234567845"),
new Book (7,3,"28 Şampiyonluk", "Kesinlikle gerçektir.", 1907,"1907 Ocak", "9781234567807"),
new Book (8,3,"16 Yıl Şampiyonluk", "Hayal ürünüdür.", 255,"10 Eylül", "9781234567816"),
new Book (9,3,"Ali Arı", "Uyanık Ceo'nun hikayesi", 551,"20 Haziran Mayıs", "9781234567800"),
};

        List<Category> categories = new List<Category>()
        {
            new Category (1,"Dünya Klasikleri"),
            new Category (2,"Türk Klasikleri"),
            new Category (3,"Bilim Kurgu"),
        };

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

            //**LINQ İlk yöntem (en geleneksel) ToList methodunda DB Connections kesilmektedir. Joinlerde kullanırız.

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
            List<Book> result = books.FindAll(b => b.Tittle.Contains(text, StringComparison.InvariantCultureIgnoreCase));
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

        //Çoktan Aza Doğru 
        public List<Book> GetAllBookOrderByTitle()
        {
            List<Book> orderedBooks = books.OrderBy(b => b.Tittle).ToList();
            return orderedBooks;
        }

        //Azdan Çoğa doğru
        public List<Book> GetAllBookOrderByDescendingTitle()
        {
            List<Book> orderedBooks = books.OrderByDescending(b => b.Tittle).ToList();
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

        public Book? GetById(int id)
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

        public Book? Remove(int id)
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
                select new BookDetailDto(
                    Id: book.Id,
                    CategoryName: category.Name,
                    Tittle: book.Tittle,
                    Description: book.Description,
                    PageSize: book.PageSize,
                    PublishDate: book.PublishDate,
                    ISBN: book.ISBN
                    );
            return result.ToList();
        }

        public List<BookDetailDto> GetDetails2()
        {
            List<BookDetailDto> details =
                books.Join(categories,

                b => b.CategoryId,
                c => c.Id,
                (book, category) => new BookDetailDto(
                    Id: book.Id,
                    CategoryName: category.Name,
                    Tittle: book.Tittle,
                    Description: book.Description,
                    PageSize: book.PageSize,
                    PublishDate: book.PublishDate,
                    ISBN: book.ISBN

                    )
                ).ToList();
            return details;
        }
    }
}
