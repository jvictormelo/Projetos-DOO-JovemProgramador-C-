using System.Reflection.Metadata;


public class Admin : IGerenciadorAluno
{

    private List<Aluno> alunos;
    public int IdAdmin{ get; set; }
    public string Senha { get; set; }

    public string Login { get; set; }


    private SGA_senacDAO sga;

    public Admin()
    {
        sga = new SGA_senacDAO();
    }

    public void MenuLogin()
    {
        sga.realizarLogin();



     }

    public void Menu()
    {
        bool rodando = true;
        while (rodando)
        {


            System.Console.WriteLine("\nMenu de Administração");
            System.Console.WriteLine("[1] - Cadastrar Aluno");
            System.Console.WriteLine("[2] - Listar Alunos");
            System.Console.WriteLine("[3] - Alterar Aluno");
            System.Console.WriteLine("[4] - Remover Aluno");
            System.Console.WriteLine("[5] - Sair");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Cadastrar();
                    break;
                case 2:
                    Listar();
                    break;
                case 3:
                    Alterar();
                    break;
                case 4:
                    Remover();
                    break;
                case 5:
                    System.Console.WriteLine("Saindo do sistema...");
                    rodando = false;
                    break;
                default:
                    System.Console.WriteLine("Opção inválida, tente novamente.");
                    Menu();
                    break;

            }
            if (escolha == 5)
            {
                rodando = false;
            }
            else
            {
                Console.WriteLine($"\nFunção {escolha} Realizada com sucesso!");
                Console.WriteLine("\nDeseja Rodar o Menu Novamente? (sim/não)");
                string escolhaMenu = Console.ReadLine();
                if (!escolhaMenu.Equals("sim", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nFechando sistema de alteração!");
                    rodando = false;
                }
            }

        }
    }

    public void Cadastrar()
    {
        sga = new SGA_senacDAO();
        sga.ListarTodosAdmins();

        Console.WriteLine("\nCadastro de Aluno");
        Aluno aluno = new Aluno();

        Console.Write($"id do Admin: {IdAdmin}");
        aluno.IdAdmin = IdAdmin;
        // aluno.IdAdmin = int.Parse(Console.ReadLine());
        Console.Write("\nNome: ");
        aluno.Nome = Console.ReadLine();

        Console.Write("Data de nascimento (formato: dd/MM/yyyy): ");
        aluno.DataNascimento = DateTime.Parse(Console.ReadLine());

        Console.Write("CPF: ");
        aluno.Cpf = Console.ReadLine();

        Console.Write("Endereço: ");
        aluno.Endereco = Console.ReadLine();

        Console.Write("Matricula: ");
        aluno.Matricula = Console.ReadLine();
        



        sga.Adicionar(aluno);
    }
    public void Listar()
    {
        sga = new SGA_senacDAO();
        sga.ListarTodos();
    }

    public void Alterar()
    {
       sga.Atualizar();

     }
    public void Remover()
{
        sga.Remover();
}
}