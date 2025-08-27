using CadastroClientes.Core;
class Program
{
    
        static void ExecutarCenariosDeTeste()
    {
        Console.WriteLine("\n Executando testes bdd");

        var cadastro = new CadastroCliente();

        Console.WriteLine("\nCenário 1: CPF válido");
        string cpfValido = "12345678909"; // Substitua por um CPF válido real se quiser testar a lógica
        var endereco1 = new Endereco("Rua A", "Centro", 10, "lages", "SC");
        var cliente1 = new Clientes(cpfValido, "João", 25, endereco1);
        if (cadastro.ValidarCpf(cpfValido))
        {
            cadastro.TesteAdicionarCliente(cpfValido, cliente1);
            Console.WriteLine("Cliente cadastrado com CPF válido");
        }
        else
        {
            Console.WriteLine("Falha ao cadastrar CPF válido");
        }

        Console.WriteLine("\nCenário 2: CPF duplicado");
        if (cadastro.ClienteJaExiste(cpfValido))
        {
            Console.WriteLine("Sistema detectou CPF duplicado");
        }
        else
        {
            Console.WriteLine("Não detectou duplicidade");
        }

        Console.WriteLine("\nCenário 3: CPF inválido");
        string cpfInvalido = "123";
        if (!cadastro.ValidarCpf(cpfInvalido))
        {
            Console.WriteLine("CPF inválido rejeitado");
        }
        else
        {
            Console.WriteLine("CPF inválido aceito");
        }

        Console.WriteLine("\nCenário 4: Editar dados do cliente");
        var clienteEditado = cadastro.ObterCliente(cpfValido);
        clienteEditado.Nome = "Carlos";
        clienteEditado.Idade = 30;

        if (clienteEditado.Nome == "Carlos" && clienteEditado.Idade == 30)
        {
            Console.WriteLine("Dados atualizados com sucesso");
        }
        else
        {
            Console.WriteLine("Erro na atualização de dados");
        }

        Console.WriteLine("\nCenário 5: Excluir cliente");
        cadastro.TesteRemoverCliente(cpfValido);
        if (!cadastro.ClienteJaExiste(cpfValido))
        {
            Console.WriteLine("Cliente removido com sucesso");
        }
        else
        {
            Console.WriteLine("Cliente não foi removido");
        }

        Console.WriteLine("\n fim dos teste bdd");
    }

    static void Main(string[] args)
    {
        ExecutarCenariosDeTeste();
        CadastroCliente cadastro = new CadastroCliente();
        int opcao;

        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Editar Cliente");
            Console.WriteLine("4 - Excluir Cliente");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    cadastro.CadastrarCliente();
                    break;
                case 2:
                    cadastro.ListarClientes();
                    break;
                case 3:
                    cadastro.EditarCliente();
                    break;
                case 4:
                    cadastro.ExcluirCliente();
                    break;
                case 5:
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 5);
    }
}
