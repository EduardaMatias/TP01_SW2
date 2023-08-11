using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class BookRepositoryCSV
    {
        public Book[] Books { get; private set; }
        public BookRepositoryCSV()
        {
            string caminhoCSV = "C:\\Users\\eduarda.matias\\Downloads\\livros.csv";
            var booksList = new List<Book>();

            using (var file = File.OpenText(caminhoCSV))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    var infoBook = line.Split(';');
                    /* var authorsInfo = infoBook[3].Split(','); 

                     var authors = new Author[authorsInfo.Length];

                     for (int i = 0; i < authorsInfo.Length; i++)
                     {
                         authors[i] = new Author { Name = authorsInfo[i].Trim(), Email = authorsInfo[1].Trim(), Gender = authorsInfo[ 2].Trim() };
                     } */

                    var authorsInfo = infoBook[3].Split('|'); // Split authors

                    var authors = new Author[authorsInfo.Length];
                    for (int i = 0; i < authorsInfo.Length; i++)
                    {
                        var authorData = authorsInfo[i].Split(','); // Split author data
                        authors[i] = new Author
                        {
                            Name = authorData[0].Trim(),
                            Email = authorData[1].Trim(),
                            Gender = authorData[2].Trim()
                        };
                    }

                    var livro = new Book(infoBook[0], Convert.ToDouble(infoBook[1]), Convert.ToInt32(infoBook[2]), authors);
                   
                    booksList.Add(livro);
                }
            }

            Books = booksList.ToArray();
        }
    }
}
