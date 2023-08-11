using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string toString()
        {

            return $"  name: {this.Name}, email: {this.Email}, gender: {this.Gender}\n";
        }
    }
}
