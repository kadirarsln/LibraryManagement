
using LibraryManagement.ConsoleUI.Models;
namespace LibraryManagement.ConsoleUI.Repository;

public abstract class BaseRepository
{
    List<Book> books = new List<Book>()
    {
new Book (new Guid("{18C11CD1-CD2D-40DB-883D-0EB6E0424F93}"),1,1,"Germinal", "Kömür Madeni", 341,"2012 Mayıs", "9781234567897"),
new Book (new Guid("{BB0FAF19-7284-47D6-96A4-CA65CA43B6C6}"),1,2,"Suç ve Ceza", "Raskolnikov", 341,"2010 Haziran", "9781234567895"),
new Book (new Guid("{BB0FAF19-7284-47D6-96A4-CA65CA43B6C7}"),1,2,"Kumarbaz", "Bir Öğretmenin Hayatı", 210,"2009 Ocak", "9781234567892"),
new Book (new Guid("{BB0FAF19-7284-47D6-96A4-CA65CA43B6C8}"),2,3,"Araba Sevdası", "Araba ile alakası olmayan kitap", 180,"2000 Ocak", "9781234567838"),
new Book (new Guid("{BB0FAF19-7284-47D6-96A4-CA65CA43B6C9}"),2,4,"Ateşten Gömlek", "Kurtuluş Savaşını anlatan gitap", 120,"2001 Eylül", "9781234567834"),
new Book (new Guid("{BB0FAF19-7284-47D6-96A4-CA65CA43B6C1}"),2,5,"Kaşağı", "Okunmaması gereken bir kitap", 95,"1993 Ocak", "9781234567845"),
new Book (Guid.NewGuid(),3,6,"28 Şampiyonluk", "Kesinlikle gerçektir.", 1907,"1907 Ocak", "9781234567807"),
new Book (new Guid("{BB0FAF19-7284-47D6-96A4-CA65CA43B6C3}"),3,6,"16 Yıl Şampiyonluk", "Hayal ürünüdür.", 255,"10 Eylül", "9781234567816"),
new Book (Guid.NewGuid(),3,7,"Ali Arı", "Uyanık Ceo'nun hikayesi", 551,"20 Haziran Mayıs", "9781234567800"),
};

    List<Category> categories = new List<Category>()
    {
        new Category (1,"Dünya Klasikleri"),
        new Category (2,"Türk Klasikleri"),
        new Category (3,"Bilim Kurgu"),
    };

    List<Author> authors = new List<Author>()
    {
        new Author(1,"Emile","Zola"),
        new Author(2,"Fyodor","Dostoyevski"),
        new Author(3,"Recaizade Mahmut","Ekrem"),
        new Author(4,"Halide Edib","Adıvar"),
        new Author(5,"Ömer","Seyfettin"),
        new Author(6,"Ali","Koç"),
        new Author(7,"Vız Vız","Ali")
    };

    List<Member> members = new List<Member>()
    {
        new Member("Sosyal Ankastre","Kadir Şehmus","Arslan",24),
        new Member("Gözlüklü","Emirhan","Çelik",22),
        new Member("Cinconlu","Ali Emre","Tanrıkulu",25),
    };

    public List<Book> Books()
    {
        return books;
    }

    public List<Category> Categories()
    {
        return categories;
    }

    public List<Author> Authors()
    {
        return authors;
    }

    public List<Member> Members()
    {
        return members;
    }

}
