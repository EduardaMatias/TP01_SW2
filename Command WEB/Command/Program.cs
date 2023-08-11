using Command;
using Microsoft.AspNetCore.Hosting;

var _repo = new AuthorRepositoryCSV();
foreach (var author in _repo.Authors)
{
    Console.WriteLine("--- AUTHOR ---");
    ImprimeAutor(author);
}

static void ImprimeAutor(Author author)
{
    Console.WriteLine(author.toString().Replace("\"", ""));
}

var _repoLivros = new BookRepositoryCSV();
foreach (var books in _repoLivros.Books)
{
    Console.WriteLine("--- BOOKS ---");
    ImprimeLivro(books);
}

static void ImprimeLivro(Book books)
{
    Console.WriteLine(books.toString().Replace("\"", ""));
}


BookRepositoryCSV bookCSV = new BookRepositoryCSV();

IWebHost host = new WebHostBuilder()
                .UseKestrel()
.UseStartup<Startup>()
                .Build();

host.Run();





