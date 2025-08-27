namespace CadastroClientes.Core;

public class CadastroCliente
{
    private Dictionary<string, Clientes> clientes = new();

    public void CadastrarCliente()
    {
        try
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            if (clientes.ContainsKey(cpf))
            {
                Console.WriteLine("CPF já cadastrado!");
                return;
            }

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

            Clientes novoCliente = new Clientes(cpf, nome, idade, endereco);

            if (ValidarCpf(cpf))
            {
                clientes[cpf] = novoCliente;
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao cadastrar cliente: {ex.Message}");
        }
    }

    public Boolean ValidarCpf(string cpf)
    {
        if (cpf.Length != 11)
        {
            System.Console.WriteLine("CPF invalido: deve conter exatamente 11 números");
            return false;
        }
        int soma1 = 0, soma2 = 0;
        int multiplicador1 = 10, multiplicador2 = 11;
        int digito1, digito2;

        foreach (char c in cpf)
        {
            soma1 += int.Parse(c.ToString()) * multiplicador1--;
            if (multiplicador1 == 1)
            {
                break;
            }
        }

        int resto = ((soma1 * 10) % 11);

        if (resto >= 10)
        {
            digito1 = 0;
        }
        else
            digito1 = resto;

        foreach (char c in cpf)
        {
            soma2 += int.Parse(c.ToString()) * multiplicador2--;
            if (multiplicador2 == 1)
            {
                break;
            }
        }
        int resto2 = ((soma2 * 10) % 11);
        if (resto2 >= 10)
        {
            digito2 = 0;
        }
        else
            digito2 = resto2;

        if (cpf[9].ToString() == digito1.ToString() && cpf[10].ToString() == digito2.ToString())
        {
            System.Console.WriteLine("CPF Valido");
            return true;
        }
        else
        {
            System.Console.WriteLine("CPF INVALIDO");
            return false;
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
        foreach (var cliente in clientes.Values)
        {
            Console.WriteLine(cliente);
        }
    }

    public void EditarCliente()
    {
        try
        {
            Console.Write("Digite o CPF do cliente a ser editado: ");
            string cpf = Console.ReadLine();

            if (!clientes.TryGetValue(cpf, out var cliente))
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Console.Write("Novo nome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Nova idade: ");
            cliente.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Cliente atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao editar cliente: {ex.Message}");
        }
    }

    public void ExcluirCliente()
    {
        try
        {
            Console.Write("Digite o CPF do cliente a ser excluído: ");
            string cpf = Console.ReadLine();

            if (clientes.Remove(cpf))
            {
                Console.WriteLine("Cliente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao excluir cliente: {ex.Message}");
        }
    }
public void TesteAdicionarCliente(string cpf, Clientes cliente)
{
    clientes[cpf] = cliente;
}

public void TesteRemoverCliente(string cpf)
{
    clientes.Remove(cpf);
}


public bool ClienteJaExiste(string cpf)
{
    return clientes.ContainsKey(cpf);
}


public Clientes ObterCliente(string cpf)
{
    return clientes[cpf];
}

}
