using Microsoft.IdentityModel.Tokens;
using Projeto_API_19_09.Contexts;
using Projeto_API_19_09.Models;

namespace Projeto_API_19_09.Repositories
{
    public class LivroRepository
    {
       private readonly ChapterContext _context;
        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }
       
    }

}     


