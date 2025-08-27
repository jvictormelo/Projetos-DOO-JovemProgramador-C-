
using MySql.Data.MySqlClient;
using SpotifeiProjeto;
using System;
using System.Collections.Generic;

class Program
{

    private static readonly DatabaseConnection dbConnection = new DatabaseConnection();
    private static readonly ArtistaRepository artistaRepository = new ArtistaRepository(dbConnection);
    private static readonly AlbumRepository albumRepository = new AlbumRepository(dbConnection);
    private static readonly UsuarioRepository usuarioRepository = new UsuarioRepository(dbConnection);
    private static readonly ConteudoRepository conteudoRepository = new ConteudoRepository(dbConnection);

    private static readonly PlanoAssinaturaRepository planoAssinaturaRepository = new PlanoAssinaturaRepository(dbConnection);


   static void Main(string[] args)
{
    Console.WriteLine("Bem-vindo ao Spotifei!");
    

    while (true)
    {
        Console.WriteLine("\nVocê deseja Fazer o Login ou se Cadastrar? [LOGIN/CADASTRAR]");
        string acao = Console.ReadLine().Trim().ToUpper();

        if (acao == "LOGIN")
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            Usuario usuarioLogado = usuarioRepository.Login(email, senha);

            if (usuarioLogado != null)
            {
                Console.WriteLine($"Bem-vindo(a), {usuarioLogado.Nome}!");

                if (usuarioLogado.TipoUsuario.ToUpper() == "ADMIN")
                    MenuAdm();
                else
                    MenuUsuario(usuarioLogado);

                break; 
            }
            else
            {
                Console.WriteLine("Email ou senha incorretos.");
            }
        }
        else if (acao == "CADASTRAR")
        {
            Console.Write("Nome do usuário: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Data de Nascimento (YYYY-MM-DD): ");
            DateTime dataNascimento;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                Console.Write("Data inválida. Digite no formato YYYY-MM-DD: ");

            Console.Write("País: ");
            string pais = Console.ReadLine();

            Console.Write("Estado: ");
            string estado = Console.ReadLine();

            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            Console.WriteLine("ID do Plano de Assinatura: \n[1] básico \n[2] premium \n[3] família");
            int planoId;
            while (!int.TryParse(Console.ReadLine(), out planoId) || planoId < 1 || planoId > 3)
            {
                Console.WriteLine("Plano inválido. Digite 1, 2 ou 3.");
            }

            Console.WriteLine("Digite o tipo de usuário [comum]/[admin]: ");
            string tipoUsuario;
            do
            {
                tipoUsuario = Console.ReadLine().Trim().ToLower();
            } while (tipoUsuario != "comum" && tipoUsuario != "admin");

            var novoUsuario = new Usuario(0, nome, email, dataNascimento, pais, estado, genero, senha, planoId, tipoUsuario);
            
            try
            {
                usuarioRepository.Add(novoUsuario);
                Console.WriteLine($"Usuário '{nome}' cadastrado com sucesso com ID {novoUsuario.Id}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar usuário: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. Digite LOGIN ou CADASTRAR.");
        }
    }
}

    static void MenuUsuario(Usuario usuario)
        {
            int opcao;
            do
            {
                Console.WriteLine($"\n=== MENU USUÁRIO: {usuario.Nome} ===");
                Console.WriteLine("1. Ver Conteúdos");
                Console.WriteLine("2. Ver Biblioteca");
                Console.WriteLine("3. Criar Playlist");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:

                        Console.WriteLine("Listando conteúdos...");
                        ListarTodos(conteudoRepository);
                        break;

                    case 2:

                        Console.WriteLine("Exibindo sua biblioteca...");
                        System.Console.WriteLine("MANUTENÇÃO: DEV TÁ TRABALHANDO ");

                        break;

                    case 3:

                        Console.WriteLine("Criando playlist...");
                        System.Console.WriteLine("MANUTENÇÃO: DEV TÁ TRABALHANDO ");

                        break;

                    case 4:
                        Console.WriteLine("Saindo do menu de usuário...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 4);
        }

    static void MenuAdm()
    {

        Console.WriteLine("BEM-VINDO AO SPOTIFEI - Sistema de Gerenciamento");


        while (true)
        {
            Console.WriteLine("\n--- MENU PRINCIPAL ---");
            Console.WriteLine("1. Gerenciar Artistas");
            Console.WriteLine("2. Gerenciar Álbuns");
            Console.WriteLine("3. Gerenciar Usuários");
            Console.WriteLine("4. Gerenciar Conteúdos (Músicas/Podcasts)");
            System.Console.WriteLine("5. Gerenciar Planos de Assinatura");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    GerenciarArtistas();
                    break;
                case "2":
                    GerenciarAlbuns();
                    break;
                case "3":
                    GerenciarUsuarios();
                    break;
                case "4":
                    GerenciarConteudos();
                    break;
                case "5":
                    GerenciarPlanosAssinatura();
                    break;
                case "6":
                    Console.WriteLine("Saindo do sistema...");
                    dbConnection.Dispose();
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    break;
            }
        }
    }

    static void GerenciarArtistas()
    {
        Console.WriteLine("\n--- Gerenciar Artistas ---");
        Console.WriteLine("1. Adicionar Artista");
        Console.WriteLine("2. Listar Artistas");
        Console.WriteLine("3. Atualizar Artista");
        Console.WriteLine("4. Deletar Artista");
        Console.Write("Escolha uma opção: ");
        string escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                Console.Write("Nome do artista: ");
                string nome = Console.ReadLine();
                Console.Write("Nacionalidade: ");
                string nacionalidade = Console.ReadLine();
                Console.Write("Data de Nascimento (YYYY-MM-DD): ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                var novoArtista = new Artista(0, nome, nacionalidade, dataNascimento);
                artistaRepository.Add(novoArtista);
                Console.WriteLine($"Artista '{nome}' adicionado com sucesso com o ID {novoArtista.Id}!");
                break;
            case "2":
                var artistas = artistaRepository.GetAll();
                Console.WriteLine("\n--- Lista de Artistas ---");
                foreach (var a in artistas)
                {
                    Console.WriteLine($"ID: {a.Id}, Nome: {a.Nome}, Nacionalidade: {a.Nacionalidade}");
                }
                break;
            case "3":
                Console.Write("ID do artista para atualizar: ");
                int idUpdate = int.Parse(Console.ReadLine());
                var artistaParaAtualizar = artistaRepository.GetById(idUpdate);
                if (artistaParaAtualizar != null)
                {
                    Console.Write($"Novo nome para '{artistaParaAtualizar.Nome}': ");
                    artistaParaAtualizar.Nome = Console.ReadLine();
                    Console.Write($"Nova nacionalidade para '{artistaParaAtualizar.Nacionalidade}': ");
                    artistaParaAtualizar.Nacionalidade = Console.ReadLine();
                    artistaRepository.Update(artistaParaAtualizar);
                    Console.WriteLine("Artista atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Artista não encontrado.");
                }
                break;
            case "4":
                Console.Write("ID do artista para deletar: ");
                int idDelete = int.Parse(Console.ReadLine());
                artistaRepository.Delete(idDelete);
                Console.WriteLine("Artista deletado com sucesso!");
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    static void GerenciarAlbuns()
    {
        Console.WriteLine("\n--- Gerenciar Álbuns ---");
        Console.WriteLine("1. Adicionar Álbum");
        Console.WriteLine("2. Listar Álbuns");
        Console.WriteLine("3. Atualizar Álbum");
        Console.WriteLine("4. Deletar Álbum");
        Console.Write("Escolha uma opção: ");
        string escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                Console.Write("Nome do álbum: ");
                string nomeAlbum = Console.ReadLine();
                Console.Write("Data de Lançamento (YYYY-MM-DD): ");
                DateTime dataLancamento = DateTime.Parse(Console.ReadLine());
                Console.Write("ID do Artista do álbum: ");
                int artistaId = int.Parse(Console.ReadLine());
                var artista = artistaRepository.GetById(artistaId);
                if (artista != null)
                {
                    var novoAlbum = new Album(0, nomeAlbum, dataLancamento);
                    albumRepository.Add(novoAlbum, artista);
                    Console.WriteLine($"Álbum '{nomeAlbum}' adicionado com sucesso com o ID {novoAlbum.Id}!");
                }
                else
                {
                    Console.WriteLine("Artista não encontrado. Não é possível adicionar o álbum.");
                }
                break;
            case "2":
                var albuns = albumRepository.GetAll();
                Console.WriteLine("\n--- Lista de Álbuns ---");
                foreach (var al in albuns)
                {
                    Console.WriteLine($"ID: {al.Id}, Nome: {al.Nome}, Lançamento: {al.DataLancamento.ToShortDateString()}");
                }
                break;
            case "3":
                Console.Write("ID do álbum para atualizar: ");
                int idUpdate = int.Parse(Console.ReadLine());
                var albumParaAtualizar = albumRepository.GetById(idUpdate);
                if (albumParaAtualizar != null)
                {
                    Console.Write($"Novo nome para '{albumParaAtualizar.Nome}': ");
                    albumParaAtualizar.Nome = Console.ReadLine();
                    Console.Write($"Nova data de lançamento (YYYY-MM-DD): ");
                    albumParaAtualizar.DataLancamento = DateTime.Parse(Console.ReadLine());
                    Console.Write("ID do novo artista: ");
                    int novoArtistaId = int.Parse(Console.ReadLine());
                    var novoArtista = artistaRepository.GetById(novoArtistaId);
                    if (novoArtista != null)
                    {
                        albumRepository.Update(albumParaAtualizar, novoArtista);
                        Console.WriteLine("Álbum atualizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Artista não encontrado. A atualização falhou.");
                    }
                }
                else
                {
                    Console.WriteLine("Álbum não encontrado.");
                }
                break;
            case "4":
                Console.Write("ID do álbum para deletar: ");
                int idDelete = int.Parse(Console.ReadLine());
                albumRepository.Delete(idDelete);
                Console.WriteLine("Álbum deletado com sucesso!");
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    static void GerenciarUsuarios()
    {
        Console.WriteLine("\n--- Gerenciar Usuários ---");
        Console.WriteLine("1. Adicionar Usuário");
        Console.WriteLine("2. Listar Usuários");
        Console.WriteLine("3. Atualizar Usuário");
        Console.WriteLine("4. Deletar Usuário");
        Console.Write("Escolha uma opção: ");
        string escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                Console.Write("Nome do usuário: ");
                string nome = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Data de Nascimento (YYYY-MM-DD): ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                Console.Write("País: ");
                string pais = Console.ReadLine();
                Console.Write("Estado: ");
                string estado = Console.ReadLine();
                Console.Write("Gênero: ");
                string genero = Console.ReadLine();
                Console.Write("Senha: ");
                string senha = Console.ReadLine();
                Console.Write("ID do Plano de Assinatura: \n[1] para basico \n[2] para premium \n[3] para familia");
                System.Console.WriteLine("Digite o ID do plano que deseja: ");
                int planoId = int.Parse(Console.ReadLine());
                System.Console.WriteLine("Digite o tipo de usuário [Comum]/[Admin]: ");
                string tipoUsuario = Console.ReadLine();
                var novoUsuario = new Usuario(0, nome, email, dataNascimento, pais, estado, genero, senha, planoId, tipoUsuario);
                usuarioRepository.Add(novoUsuario);
                Console.WriteLine($"Usuário '{nome}' adicionado com sucesso com o ID {novoUsuario.Id}!");
                break;
            case "2":
                var usuarios = usuarioRepository.GetAll();
                Console.WriteLine("\n--- Lista de Usuários ---");
                foreach (var u in usuarios)
                {
                    Console.WriteLine($"ID: {u.Id}, Nome: {u.Nome}, Email: {u.Email}, Status: {u.Status}");
                }
                break;
            case "3":
                Console.Write("ID do usuário para atualizar: ");
                int idUpdate = int.Parse(Console.ReadLine());
                var usuarioParaAtualizar = usuarioRepository.GetById(idUpdate);
                if (usuarioParaAtualizar != null)
                {
                    Console.Write($"Novo email para '{usuarioParaAtualizar.Email}': ");
                    usuarioParaAtualizar.Email = Console.ReadLine(); 
                    Console.Write("Nova senha: ");
                    usuarioParaAtualizar.Senha = Console.ReadLine();
                    usuarioRepository.Update(usuarioParaAtualizar);
                    Console.WriteLine("Usuário atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado.");
                }
                break;
            case "4":
                Console.Write("ID do usuário para deletar: ");
                int idDelete = int.Parse(Console.ReadLine());
                usuarioRepository.Delete(idDelete);
                Console.WriteLine("Usuário deletado com sucesso!");
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    static void GerenciarConteudos()
    {
        Console.WriteLine("\n--- Gerenciar Conteúdos ---");
        Console.WriteLine("1 - Adicionar Conteúdo");
        Console.WriteLine("2 - Listar Todos os Conteúdos");
        Console.WriteLine("3 - Atualizar Conteúdo");
        Console.WriteLine("4 - Deletar Conteúdo");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
        string escolha = Console.ReadLine();
        try
        {
            switch (escolha)
            {
                case "1":
                    AdicionarConteudo(conteudoRepository);
                    break;
                case "2":
                    ListarTodos(conteudoRepository);
                    break;
                case "3":
                    AtualizarConteudo(conteudoRepository);
                    break;
                case "4":
                    DeletarConteudo(conteudoRepository);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    


       
    }
    static void GerenciarPlanosAssinatura()
    {
        PlanoAssinaturaRepository plano = new PlanoAssinaturaRepository(dbConnection);
        Console.WriteLine("\n--- Gerenciar Planos de Assinatura ---");
        Console.WriteLine("1. Adicionar Plano de Assinatura ");
        Console.WriteLine("2. Listar Planos de Assinatura");
        Console.WriteLine("3. Atualizar Plano de Assinatura");
        Console.WriteLine("4. Deletar Plano de Assinatura");
        Console.Write("Escolha uma opção: ");
        string escolha = Console.ReadLine();

        switch (escolha)
        {
            case "1":
                Console.Write("Tipo do Plano: ");
                string tipoPlano = Console.ReadLine();
                Console.Write("Preço Mensal: ");
                decimal precoMensal = decimal.Parse(Console.ReadLine());
                Console.Write("Máximo de Perfis: ");
                int maxPerfis = int.Parse(Console.ReadLine());
                Console.Write("Qualidade de Áudio: ");
                string qualidadeAudio = Console.ReadLine();
                Console.Write("Quantidade de Anúncios: ");
                string quantidadeAnuncios = Console.ReadLine();
                var novoPlano = new PlanoAssinatura(0, tipoPlano, precoMensal, maxPerfis, qualidadeAudio, quantidadeAnuncios);
                planoAssinaturaRepository.Add(novoPlano);

                Console.WriteLine($"Plano '{tipoPlano}' adicionado com sucesso!");
                break;

            case "2":
                Console.WriteLine("\n--- Lista de Planos de Assinatura ---");
                plano.GetAll();
                break;

            case "3":
                plano.Update();
                break;
            case "4":
                plano.Delete();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    
        static void AdicionarConteudo(ConteudoRepository repo)
    {
        Console.Write("Digite o título: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a categoria (Musica ou Podcast): ");
        string categoria = Console.ReadLine();

        Console.Write("Classificação (ou deixe em branco): ");
        string classificacao = Console.ReadLine();
        classificacao = string.IsNullOrWhiteSpace(classificacao) ? null : classificacao;

        Console.Write("Duração em segundos: ");
        int duracaoSegundos = int.Parse(Console.ReadLine());

        Console.Write("ID do Artista (ou deixe em branco): ");
        string artistaInput = Console.ReadLine();
        int? artistaId = string.IsNullOrWhiteSpace(artistaInput) ? null : int.Parse(artistaInput);

        Console.Write("Tipo do Conteúdo: ");
        string tipoConteudo = Console.ReadLine();

        if (categoria.ToLower() == "musica")
        {
            Console.Write("ID do Álbum (ou deixe em branco): ");
            string albumInput = Console.ReadLine();
            int? albumId = string.IsNullOrWhiteSpace(albumInput) ? null : int.Parse(albumInput);

            var musica = new Musica
            {
                Titulo = titulo,
                Categoria = "Musica",
                Classificacao = classificacao,
                Duracao = TimeSpan.FromSeconds(duracaoSegundos),
                ArtistaId = artistaId,
                TipoConteudo = tipoConteudo,
                AlbumId = albumId
            };

            int id = repo.Add(musica);
            Console.WriteLine($"Música adicionada com ID: {id}");
        }
        else if (categoria.ToLower() == "podcast")
        {
            Console.Write("Nome do Apresentador: ");
            string apresentador = Console.ReadLine();

            Console.Write("Número do Episódio (ou deixe em branco): ");
            string numeroEp = Console.ReadLine();

            var podcast = new Podcast
            {
                Titulo = titulo,
                Categoria = "Podcast",
                Classificacao = classificacao,
                Duracao = TimeSpan.FromSeconds(duracaoSegundos),
                ArtistaId = artistaId,
                TipoConteudo = tipoConteudo,
                Apresentador = apresentador,
                NumeroEpisodio = string.IsNullOrWhiteSpace(numeroEp) ? null : numeroEp
            };

            int id = repo.Add(podcast);
            Console.WriteLine($"Podcast adicionado com ID: {id}");
        }
        else
        {
            Console.WriteLine("Categoria inválida!");
        }
    }

 
    static void ListarTodos(ConteudoRepository repo)
    {
        var lista = repo.ListarTodos();
        foreach (var conteudo in lista)
        {
            ExibirConteudo(conteudo);
        }
    }

    static void AtualizarConteudo(ConteudoRepository repo)
    {
        ListarTodos(repo);
        Console.Write("Digite o ID do conteúdo a atualizar: ");
        int id = int.Parse(Console.ReadLine());

        var conteudo = repo.GetById(id);
        if (conteudo == null)
        {
            Console.WriteLine("Conteúdo não encontrado.");
            return;
        }

        Console.Write("Novo título (ou pressione Enter para manter): ");
        string novoTitulo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoTitulo))
            conteudo.Titulo = novoTitulo;

        repo.Update(conteudo);
        Console.WriteLine("Conteúdo atualizado.");
    }

    static void DeletarConteudo(ConteudoRepository repo)
    {
        ListarTodos(repo);
        Console.Write("Digite o ID do conteúdo a deletar: ");
        int id = int.Parse(Console.ReadLine());

        repo.Delete(id);
        Console.WriteLine("Conteúdo deletado.");
    }

    static void ExibirConteudo(Conteudo conteudo)
    {
        Console.WriteLine($"\nID: {conteudo.Id}");
        Console.WriteLine($"Título: {conteudo.Titulo}");
        Console.WriteLine($"Categoria: {conteudo.Categoria}");
        Console.WriteLine($"Classificação: {conteudo.Classificacao}");
        Console.WriteLine($"Duração: {conteudo.Duracao}");
        Console.WriteLine($"ArtistaId: {conteudo.ArtistaId}");
        Console.WriteLine($"TipoConteudo: {conteudo.TipoConteudo}");

        if (conteudo is Musica m)
        {
            Console.WriteLine($"AlbumId: {m.AlbumId}");
        }
        else if (conteudo is Podcast p)
        {
            Console.WriteLine($"Apresentador: {p.Apresentador}");
            Console.WriteLine($"Número do Episódio: {p.NumeroEpisodio}");
        }
    }
}

