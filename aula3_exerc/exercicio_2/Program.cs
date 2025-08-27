class Program
    {
        static void Main(string[] args)
        {
            CadastroClientes cadastro = new CadastroClientes();
            int opcao;

            do
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Clientes");
                Console.WriteLine("3 - Sair");
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
                        Console.WriteLine("Encerrando...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 3);
        }
    }
