//(Record) Kitap-> Id,Tittle, Description, PageSize,PublishDate,ISBN, Stok
//(Record) Author->Id, Name, Surname
//(Class) Category-> Id, Name

//Kategori eklerken Id veya Name alanları benzersizolacak

//Kitaplar Listesi oluşturunuz.
//Yazarlar listesi oluşturunuz.
//Kategori listesi oluşturunuz.

//Yazarları ekrana bastıran kodu yazınız. 
//Kitapları ekrana bastıran kodu yazınız.
//Kategorileri ekrana bastıran kodu yazınız.

//Kitapları sayfa sayısına göre filtreleyen kodu yazınız.
//Kütüphanedeki tüm kitapların sayfa sayısı toplamını hesaplayan kodu yazınız.
//Kitap başlığına göre filtreleme işlemi yapınız.
//ISBN Numarasına göre ilgili kitabı getiriniz.
//Kitaplar listesine uyeni bir kitap ekleyin. EKLENDİKTEN SONRA LİSTEYİ EKRAN CIKTISI OLARAK VERİNİZ. (Verileri kullanıcıdan alınız.)
// ** Kitap eklerken Id veya ISBN numarası benzersiz olacak. Aynı olduğu durumda uyarı verecek.

//Kullanıcı ilk Id girdiği zaman o Id göre kitabı silen ve yeni listeyi ekrana bastıran bir yaklaşım.

//Kullanıcıdan ilk başta Id değeri alıp arama yaptıktan sonra eğer o Id ait biir kitap yoksa "İlgili Id ait kitap bulunamadı" yazsın.
//* Güncellenecek olan değerler kullanıcıdan alınacak.

//Kullanıcıdan bir kitap almasını iteyen kodu yazınız. Kitap stok durumunu kontrol ediniz. Stok varsa alınsın ve alındı yazısı yazsın,
//Kitap 1 tane varsa alınsın ve 0 olursa listeden silinsin.

//Prime Örnekler (LINQ Yöntemi ile de yapılacaktır.)
// - BookDetail adında bir record oluşturup şu değerler listelenecek,
//Kitap Id, KitapBaşlığı, KitapAçıklaması, KitapSayfa, ISBN, YaazarAdı ve KategoriAdı

//**Kullanıcıdan sayfa sayısı PageIndex ve PageSize değerlerini alarak, sayfalama desteği getiriniz

using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Repository;
using LibraryManagement.ConsoleUI.Service;
using System.Threading.Channels;

BookService bookService = new BookService();

//bookService.GetAll();
//bookService.GetDetails();
//bookService.GetById(4);
//bookService.GetBookByISBN("a");

//bookService.GetAllBookOrderByTitle();
//bookService.GetAllBookOrderByDescendingTitle();

//bookService.GetBookMaxPageSize();
//bookService.GetBookMinPageSize();

//bookService.GetAllBooksByTitleContains("GER");
//bookService.GetAllBooksByPageSizeFİlter(100, 300);

//bookService.GetDetails();
//bookService.GetAllAuthorAndBookDetails();
bookService.GetAllDetailsByCategoryId(1);
Console.WriteLine("\n**********************************************************\n");
bookService.GetAllDetailsByCategoryId2(2);


//GetAllBooks();
//GetAllAuthors();
//GetAllCategories();
//GetAllBooksByPageSizeFilter();
//PageSizeTotalCalculator();

//BookRepository bookRepository = new BookRepository();

//bookRepository.GetAllBooksByTitleContains();

//GetBookByISBN();

//AddBook();
//AddAuthor();

//void GetAllBooks()
//{
//    PrintAyirac("Kitapları Listele");
//    foreach (Book book in books)
//    {
//        Console.WriteLine(book);
//    }
//}

//void GetAllCategories()
//{
//    PrintAyirac("Kategorileri Listele");
//    foreach (Category category in categories)
//    {
//        Console.WriteLine(category);
//    }
//    Console.WriteLine();

//    categories.ForEach(categorie => Console.WriteLine($"Kategori Id: {categorie.Id} Kategori Adı: {categorie.Name}"));
//}

//void GetAllAuthors()
//{
//    PrintAyirac("Yazarları Listele");

//    foreach (Author author in authors)
//    {
//        Console.WriteLine(author);
//    }

//    //authors.ForEach(author => Console.WriteLine($"Yazar Id: {author.Id} Yazar Adı: {author.Name} Yazar Soyadı: {author.Surname}"));

//}

void PrintAyirac(string metin)
{
    Console.WriteLine("-------------------------------------------------------");
    Console.WriteLine($"**************** {metin} ****************");
    Console.WriteLine("-------------------------------------------------------");
}

//void GetAllBooksByPageSizeFilter()
//{
//    PrintAyirac("Sayfa Sayısına Göre Fİltreleme");

//    Console.WriteLine("Lütfen minimum değeri giriniz: ");
//    int min = Convert.ToInt32(Console.ReadLine());

//    Console.WriteLine("Lütfen maximum değeri giriniz: ");
//    int max = Convert.ToInt32(Console.ReadLine());

//    foreach (Book book in books)
//    {
//        if (book.PageSize <= max && book.PageSize >= min)
//        {
//            Console.WriteLine(book);
//        }
//    }
//}

//void PageSizeTotalCalculator()
//{
//    //int total = 0;
//    //books.ForEach(book =>
//    //{
//    //    total += book.PageSize;
//    //});
//    //Console.WriteLine(total);

//    //int total = 0;
//    //foreach (Book book in books)
//    //{
//    //    total += book.PageSize;
//    //}
//    //Console.WriteLine(total);

//    //Console.WriteLine(books.Sum(book => book.PageSize));
//}

//void GetAllBooksByTitleContains()
//{
//    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
//    string text = Console.ReadLine();

//    foreach (Book book in books)
//    {
//        if (book.Tittle.Contains(text, StringComparison.InvariantCultureIgnoreCase))
//        {
//            Console.WriteLine(book);
//        }
//    }
//}

//void GetBookByISBN()
//{
//    Console.WriteLine("Lütfen bir ISBN giriniz: ");
//    string isbn = Console.ReadLine();

//    foreach (Book book in books)
//    {
//        if (book.ISBN == isbn)
//        {
//            Console.WriteLine(book);
//            break;
//        }
//        //else { Console.WriteLine("Hatalı Numara Girdiniz!!!"); }
//    }
//}

void GetBookInputs(out int id,
    out string tittle,
    out string description,
    out int pageSize,
    out string publishDate,
    out string isbn)
{
    Console.WriteLine("Lütfen kitap ID giriniz: ");
    id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Başlığını giriniz: ");
    tittle = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    description = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Sayfa Sayısını giriniz: ");
    pageSize = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    publishDate = Console.ReadLine();

    Console.WriteLine("Lütfen ISBN giriniz: ");
    isbn = Console.ReadLine();
}

//Kitap dönebilmek adına validasyonlarımızı yazabilmek için Kitap dönüyoruz.
Book GetBookInputs2()
{
    PrintAyirac("Kitap Ekleme: ");
    Console.WriteLine("Lütfen kitap ID giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Lütfen kitap Başlığını giriniz: ");
    string tittle = Console.ReadLine();
    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    string description = Console.ReadLine();
    Console.WriteLine("Lütfen kitap Sayfa Sayısını giriniz: ");
    int pageSize = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    string publishDate = Console.ReadLine();
    Console.WriteLine("Lütfen ISBN giriniz: ");
    string isbn = Console.ReadLine();

    Book book = new Book(Guid.NewGuid(), 1, 1, tittle, description, pageSize, publishDate, isbn);
    return book;
}

//bool AddBookValidator(Book book)
//{
//    bool isUnique = true;

//    foreach (Book item in books)
//    {
//        if (item.Id == book.Id || item.ISBN == book.ISBN)
//        {
//            isUnique = false;
//            break;
//        }
//    }
//    return isUnique;
//}

//void AddBook()
//{
//    //------------- 1.YÖNTEM -------------
//    //int id;
//    //string tittle;
//    //string description;
//    //int pageSize;
//    //string publishDate;
//    //string isbn;

//    //GetBookInputs(out id,  out tittle,out description,out pageSize,out publishDate,out isbn);

//    //PrintAyirac("Kitap Ekleme: ");
//    //Console.WriteLine("Lütfen kitap ID giriniz: ");
//    //int id = Convert.ToInt32(Console.ReadLine());
//    //Console.WriteLine("Lütfen kitap Başlığını giriniz: ");
//    //string tittle = Console.ReadLine();
//    //Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
//    //string description = Console.ReadLine();
//    //Console.WriteLine("Lütfen kitap Sayfa Sayısını giriniz: ");
//    //int pageSize = Convert.ToInt32(Console.ReadLine());
//    //Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
//    //string publishDate = Console.ReadLine();
//    //Console.WriteLine("Lütfen ISBN giriniz: ");
//    //string isbn = Console.ReadLine();

//    Book book = GetBookInputs2();
//    bool isUnique = AddBookValidator(book);

//    //Benzersiz değilse
//    if (!isUnique)
//    {
//        Console.WriteLine("Girmiş olduğunuz kitap benzersiz değildir.");
//        return;
//    }
//    books.Add(book);
//    //GetAllBooks();

//    //------ Kötü Kod -------
//    //foreach (Book item in books)
//    //{
//    //    Console.WriteLine(item);
//    //}
//}


//Category GetCategoryInputs()
//{
//    PrintAyirac("Kitap Ekleme: ");
//    Console.WriteLine("Lütfen kategori ID giriniz: ");
//    int id = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("Lütfen kategori Başlığını giriniz: ");
//    string name = Console.ReadLine();

//    Category category = new Category(id, name);
//    return category;
//}

//bool AddCategoryValidator(Category category)
//{
//    bool isUnique = true;

//    foreach (Category item in categories)
//    {
//        if (item.Id == category.Id || item.Name == category.Name)
//        {
//            isUnique = false;
//            break;
//        }
//    }
//    return isUnique;
//}

//void AddCategory()
//{
//    Category category = GetCategoryInputs();
//    bool isUnique = true;
//    if (!isUnique)
//    {
//        Console.WriteLine("Girmiş olduğunuz Kategori benzersiz değildir.");
//        return;
//    }
//    categories.Add(category);
//    GetAllCategories();
//}


//Author GetAuthorInputs()
//{
//    PrintAyirac("Kitap Ekleme: ");
//    Console.WriteLine("Lütfen Yazar ID giriniz: ");
//    int id = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine("Lütfen Yazar Adı giriniz: ");
//    string name = Console.ReadLine();
//    Console.WriteLine("Lütfen Yazar Soyadı Adı giriniz: ");
//    string surname = Console.ReadLine();

//    Author author = new Author(id, name, surname);
//    return author;
//}

//bool AddAuthorValidator(Author author)
//{
//    bool isUnique = true;
//    foreach (Author item in authors)
//    {
//        //string fullname = item.Name + item.Surname;
//        //string fullname2 = author.Name + author.Surname;

//        if (item.Id == author.Id || (item.Name == author.Name && item.Surname == author.Surname))
//        {
//            isUnique = false;
//            break;
//        }
//    }
//    return isUnique;
//}

//void AddAuthor()
//{
//    Author author = GetAuthorInputs();
//    bool isUnique = AddAuthorValidator(author);

//    if (!isUnique)
//    {
//        Console.WriteLine("Girmiş olduğunuz Yazar benzersiz değildir.");
//        return;
//    }
//    authors.Add(author);
//    GetAllAuthors();
//}