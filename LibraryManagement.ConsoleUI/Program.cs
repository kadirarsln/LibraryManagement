//(Record) Kitap-> Id,Tittle, Description, PageSize,PublishDate,ISBN, Stok
//(Record) Author->Id, Name, Surname
//(Class) Category-> Id, Name

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

using LibraryManagement.ConsoleUI;

List<Book> books = new List<Book>() {
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

List<Author> authors = new List<Author>()
{
    new Author(1,"Emile","Zola"),
    new Author(2,"Fyodor","Dostoyevski"),
    new Author(3,"Recaizade Mahmut","Ekrem"),
    new Author(4,"Halide Edib","Adıvar"),
    new Author(5,"Ömer","Seyfettin"),
    new Author(5,"Ali","Koç"),
    new Author(6,"Vız Vız","Ali")
};

List<Category> categories = new List<Category>()
{
    new Category (1,"Dünya Klasikleri"),
    new Category (2,"Türk Klasikleri"),
    new Category (3,"Bilim Kurgu"),
};

GetAllBooks();
GetAllAuthors();
GetAllCategories();


void GetAllBooks()
{
    PrintAyirac("Kitapları Listele: ");
    foreach (Book book in books)
    {
        Console.WriteLine(book);
    }
}

void GetAllCategories()
{
    PrintAyirac("Kategorileri Listele: ");
    foreach (Category category in categories)
    {
        Console.WriteLine(category);
    }
    Console.WriteLine();

    //categories.ForEach(categorie => Console.WriteLine($"Kategori Id: {categorie.Id} Kategori Adı: {categorie.Name}"));
}

void GetAllAuthors()
{
    PrintAyirac("Yazarları Listele: ");

    foreach (Author author in authors)
    {
        Console.WriteLine(author);
    }

    //authors.ForEach(author => Console.WriteLine($"Yazar Id: {author.Id} Yazar Adı: {author.Name} Yazar Soyadı: {author.Surname}"));

}

void PrintAyirac(string metin)
{
    Console.WriteLine(metin);
    Console.WriteLine("-----------------------------------------------");
}