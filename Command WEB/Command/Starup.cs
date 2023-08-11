using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Command
{
    internal class Starup
    {
       public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("/NomeLivros", NomesLivros);
            builder.MapRoute("/Autores");
            builder.MapRoute("/DadosLivro");
            builder.MapRoute("/livro/ApresentarLivro/{nome}/");
        }
        public Task NomesLivros(HttpContext context)

    }
}
