using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class CategoryRepository
    {
        List<Category> categories = new List<Category>()
        {
            new Category (1,"Dünya Klasikleri"),
            new Category (2,"Türk Klasikleri"),
            new Category (3,"Bilim Kurgu"),
        };

        public List<Category> GetAll()
        {
            return categories;
        }
    }
}
