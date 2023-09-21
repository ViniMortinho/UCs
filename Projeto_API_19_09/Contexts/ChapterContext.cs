using Microsoft.EntityFrameworkCore;
using Projeto_API_19_09.Models;
using System.Security.Cryptography.X509Certificates;

namespace Projeto_API_19_09.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }

        public ChapterContext(DbContextOptions<ChapterContext> options): base(options) { }
        //vamos utilizar esse metodo para configurar o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                //cada provedor tem sua sintaxe
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-F2ABGDE\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true;  TrustServerCertificate = True");

                //data source = caminho do banco
                // intial catalog = nome do banco de dados que você vai usar
                // integrated security = se você esta usando o login padrão ou com senha e id
                // ou User Id=meuusuario;Password=minhasenha;
                //trust server certificate = fazendo o c# confiar na conexão
            }
        }
        //entidade que vamos usar:
        public DbSet<Livro> Livros { get; set; }
    }
}
