'<h1>PInd_Back02</h1>
<p>Este repositório é referente ao segundo dia do plantão individual sobre BackEnd. Serão abordadas as UCs 13, 14, 15</p>

 [Exemplo de imagem](img/gifs-momentos-de-felicidade.gif)
 ---
> [!IMPORTANT]
> O que precisamos ter para conseguir fazer a atividade?
> 1) Visual Studio
> 2) SSM
> 3) SQL Server
 ---

E como conseguimos? Precisamos instalar!!!!!!
- [ ] Instalação do Visual Studio:
> https://visualstudio.microsoft.com/pt-br/downloads

- [ ] Instalação do SSM:
> https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16

- [ ] Instalação do SQL Server:
> https://www.microsoft.com/pt-br/sql-server/sql-server-downloads

 ---


Ambiente ok? Perfeito!

Então primeiro precisaremos acessar o SSM. E dentro dele, abrir uma nova consulta para adicionar esses scripts, para criar e manipular o banco de dados:
```
CREATE DATABASE Chapter

USE Chapter

CREATE TABLE Livros (
	id INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(150) NOT NULL,
	QuantidadePaginas INT,
	Disponivel BIT
)

INSERT INTO Livros (Titulo, QuantidadePaginas, Disponivel)
VALUES ('Titulo 1', 220, 1)

INSERT INTO Livros (Titulo, QuantidadePaginas, Disponivel)
VALUES ('Biblia', 500, 1)

SELECT * FROM Livros

UPDATE Livros SET Titulo = 'Senhor dos Aneis' WHERE id = 1;

DELETE FROM Livros WHERE id = 3;
```

Em seguida, abra o VISUAL STUDIO e crie um projeto (API web do ASP.NET core - C#)

Dentro do projeto já criado, você precisará excluir os seguintes arquivos e pastas:
1-    WeatherForecast.cs
2-    WeatherForecastController.cs(Dentro da pasta controller)

Em seguida, no projeto dentro do Visual Studio Code, é preciso criar as seguintes pastas:
- criar a pasta Models
- criar a pasta Repositories
- criar a pasta Contexts

## Model
Dentro de Models, você irá criar uma classe chamada "Livro.cs" e em seguida, irá adicionar dentro da classes os atributos.

```
namespace ChapterFST1.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public int QuantidadePaginas { get; set; }

        public bool Disponivel { get; set; }
    }
}
```

Em seguida, 
Vamos adicionar pacote do nuget do sql server. Para isso, voccê irá clicar no botão
Clicar com o botão direito em cima do nome do projeto, e e seguida selecione o "Gerenciar Pacotes do NuGet"

Em seguida, procure por e clique em "Instalar": 
<img src="https://i.stack.imgur.com/XEYvs.png">

## Context
Agora, na  pasta "Contexts" criaremos uma classe chamada ChapterContext.cs
```
using ChapterFST1.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterFST1.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {
        }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source = CYBERNOTE-03-1\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true; TrustServerCertificate=True");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }

    }
}

```

## Repository

Dentro da pasta  "Repositories", crie uma classe chamada "LivroRepository.cs"

```
using ChapterFST1.Contexts;
using ChapterFST1.Models;

namespace ChapterFST1.Repositories
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

```
## Controller

Dentro da pasta  "Controller", crie um CONTROLADOR chamado "LivoController.cs"

```
using ChapterFST1.Models;
using ChapterFST1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterFST1.Controllers
{
    [Produces("application/json")]
    
    [Route("api/[controller]")]

    [ApiController]

    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}

```

## Program

Dentro do arquivo program.cs

```
builder.Services.AddScoped<ChapterContext, ChapterContext>();

builder.Services.AddTransient<LivroRepository, LivroRepository>();

```

E agora, vamos testar????

Vamos precisar rodar a API clicando no playzinho verde lá no menu do Visual Studio. Ele vai abrir o Swagger... Ele é parecido com o postman, vai fazer requisições utilizando o protocolo http e você consegue testar a api através dele, além disso, ele também serve como documentação
-clicar em try it out
-clicar em execute

