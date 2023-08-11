using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Book
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public Author[] Authors { get; set; } 
        public Book(string name, double price, Author[] authors)
        {
            Name = name;
            Price = price;
            this.Authors = authors;
        }

        public Book(string name, double price, int qty, Author[] authors)
        {
            Name = name;
            Price = price;
            Qty = qty;
            this.Authors = authors;
         
        }
        public string getAuthorNames()
        {
            var _repo = "";
            foreach (var author in this.Authors)
            {
                _repo += author.Name + ", ";
            }
            return _repo;
        }
        public string toString()
        {
            string autores="";
        
            foreach (Author author in this.Authors)
            {
                autores += author.toString();
            }
            return $"Book: name: {Name}, price: {Price}, qty: {Qty}, \nauthors:\n{autores}";
        }
    }
}
