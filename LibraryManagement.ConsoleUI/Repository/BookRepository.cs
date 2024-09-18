using LibraryManagement.ConsoleUI.Models;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class BookRepository
    {
        List<Book> books = new List<Book>()
        {
new Book (1,"Germinal", "Kömür Madeni", 341,"2012 Mayıs", "9781234567897"),
new Book (2,"Suç ve Ceza", "Raskolnikov", 341,"2010 Haziran", "9781234567895"),
new Book (3,"Kumarbaz", "Bir Öğretmenin Hayatı", 210,"2009 Ocak", "9781234567892"),
new Book (4,"Araba Sevdası", "Araba ile alakası olmayan kitap", 180,"2000 Ocak", "9781234567838"),
new Book (5,"Ateşten Gömlek", "Kurtuluş Savaşını anlatan gitap", 120,"2001 Eylül", "9781234567834"),
new Book (6,"Kaşağı", "Okunmaması gereken bir kitap", 95,"1993 Ocak", "9781234567845"),
new Book (7,"28 Şampiyonluk", "Kesinlikle gerçektir.", 1907,"1907 Ocak", "9781234567807"),
new Book (8,"16 Yıl Şampiyonluk", "Hayal ürünüdür.", 255,"10 Eylül", "9781234567816"),
new Book (9,"Ali Arı", "Uyanık Ceo'nun hikayesi", 551,"20 Haziran Mayıs", "9781234567800"),
};

        public List<Book> GetAll()
        {
            return books;
        }

        public List<Book> GetAllBooksByPageSizeFilter(int min, int max)
        {
            List<Book> filteredBooks = new List<Book>();

            foreach (Book book in books)
            {
                if (book.PageSize <= max && book.PageSize >= min)
                {
                    filteredBooks.Add(book);
                }
            }
            return filteredBooks;
        }

        public double PageSizeTotalCalculator()
        {
            double total = books.Sum(book => book.PageSize);
            return total;
        }

        public List<Book> GetAllBooksByTitleContains(string text)
        {
            List<Book> filteredBooksText = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Tittle.Contains(text, StringComparison.InvariantCultureIgnoreCase))
                {
                    filteredBooksText.Add(book);
                }
            }
            return filteredBooksText;
        }

        //Null gelebilir. Önden uyarıyoruz.
        public Book? GetBookByISBN(string isbn)
        {
            Book? book1 = null;  //new ile tanımlarsak Bütün değerlerini girmemiz gerekir.

            foreach (Book item in books)
            {
                if (item.ISBN == isbn)
                {
                    book1 = item;
                }
            }

            //return book1 is null ? null : book1;

            /* return book1 ?? book1;*/// varsa döner ?? varsa
            if (book1 == null)
            {
                return null;
            }
            return book1;
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
    }
}
