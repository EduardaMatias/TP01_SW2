using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Command;

namespace Command
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Book/BuscaLivroNome/{nome}", buscaLivroNome);
            builder.MapRoute("Book/BuscaLivroNomeAuthor/{nome}", buscaLivroNomeAutor);
            builder.MapRoute("Livro/ApresentarLivro", buscaLivro);
            var rotas = builder.Build();

            app.UseRouter(rotas);
        }
        public Task buscaLivroNome(HttpContext context)
        {
            try
            {
                var nome = context.GetRouteValue("nome").ToString();
                var repo = new BookRepositoryCSV();
                var retorno = repo.Library.buscaLivroNome(nome).ToString();
                return context.Response.WriteAsync(retorno);
            }
            catch (Exception)
            {
                return context.Response.WriteAsync("Caminho inexistente.");
            }
        }
        public Task buscaLivroNomeAutor(HttpContext context)
        {
            try
            {
                var nome = context.GetRouteValue("nome").ToString();
                var repo = new BookRepositoryCSV();
                var retorno = repo.Library.buscaLivroNomeAuthor(nome).ToString();
                return context.Response.WriteAsync(retorno);
            }
            catch (Exception)
            {
                return context.Response.WriteAsync("Caminho inexistente.");
            }
        }
        public Task buscaLivro(HttpContext context)
        {
            var repo = new BookRepositoryCSV();
            var conteudo = CarregandoHTML("Livro");
            try
            {
                foreach (var item in repo.Library.Livros)
                {
                    conteudo = conteudo.Replace("#LISTA#", $"<li>{item.Name}</li>" +
                        $"<li>{item.getAuthorNames()}</li>" +
                        $"<li>{item.Price}</li>" +
                        $"<li>{item.Qty}</li></br>#LISTA#");
                    //var retorno = repo.Library.ToString();
                }
                return context.Response.WriteAsync(conteudo);
            }
            catch (Exception)
            {
                return context.Response.WriteAsync("Caminho inexistente.");
            }
        }
        private string CarregandoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"../../../HTML/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
