using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        //    List<Author> authors = new List<Author>()
        //    {
        //        new Author(1,"Emile","Zola"),
        //        new Author(2,"Fyodor","Dostoyevski"),
        //        new Author(3,"Recaizade Mahmut","Ekrem"),
        //        new Author(4,"Halide Edib","Adıvar"),
        //        new Author(5,"Ömer","Seyfettin"),
        //        new Author(5,"Ali","Koç"),
        //        new Author(6,"Vız Vız","Ali")
        //    };

        //    public List<Author> GetAll() { return authors; }
        //}
        public Author Add(Author item)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Author? Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Author? Update(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
