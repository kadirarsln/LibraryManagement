using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI.Models
{
    //Record olduğu için Miras aldığımız sınıfta Record olacaktır.
    public sealed class Author : Entity<int>
    {
        public Author()
        {
        }

        public Author(int id, string name, string surname) : base(id)    // Super classın içersindekileri istersek kullanırız.
                                                                         // Constructer a ulaşmamızı sağlar. Base keywordu. Id için. This ise boş olanı çalıştırır.
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
