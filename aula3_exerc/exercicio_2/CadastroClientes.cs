  public class CadastroClientes
    {
        private List<Clientes> clientes = new List<Clientes>();

        public void CadastrarCliente()
        {
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Idade: ");
                int idade = int.Parse(Console.ReadLine());

                Console.Write("Rua: ");
                string rua = Console.ReadLine();

                Console.Write("Bairro: ");
                string bairro = Console.ReadLine();

                Console.Write("Número: ");
                int numero = int.Parse(Console.ReadLine());

                Console.Write("Cidade: ");
                string cidade = Console.ReadLine();

                Console.Write("Estado (sigla): ");
                string estado = Console.ReadLine();

                Endereco endereco = new Endereco(rua, bairro, numero, cidade, estado);
                Clientes novoCliente = new Clientes(nome, idade, endereco);

                clientes.Add(novoCliente);
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar cliente: {ex.Message}");
            }
        }

        public void ListarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            Console.WriteLine("\n--- Lista de Clientes ---");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"{cliente.Nome} - {cliente.Endereco.Cidade} ({cliente.Endereco.Estado})");
            }
        }
    }
