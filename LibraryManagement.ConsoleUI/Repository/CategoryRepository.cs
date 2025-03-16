using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        //List<Category> categories = new List<Category>()
        //{
        //    new Category (1,"Dünya Klasikleri"),
        //    new Category (2,"Türk Klasikleri"),
        //    new Category (3,"Bilim Kurgu"),
        //};

        //public List<Category> GetAll()
        //{
        //    return categories;
        //}
        public Category Add(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Category? Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Category? Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
