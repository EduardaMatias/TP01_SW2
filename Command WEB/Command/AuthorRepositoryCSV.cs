using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class AuthorRepositoryCSV
    {
        public Author[] Authors { get; private set; }

        public AuthorRepositoryCSV()
        {
            string caminhoCSV = "D:\\IFSP\\3 ano\\2 semestre\\SWII6\\TP01_SW2-master\\livros.csv";
            var authorsList = new List<Author>();

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
                        authorsList.Add(authors[i]);
                    }

                }

                Authors = authorsList.ToArray();
            }


        }
    }
}
