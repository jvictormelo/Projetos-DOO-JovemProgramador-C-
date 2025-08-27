namespace Calculadora.Core;

public class Historico
{
    private Dictionary<int, Operacao> operacoes = new();

    public void Adicionar()
    {
        try
        {
            Console.Write("Tipo ([1] soma, [2] subtracao, [3] multiplicacao, [4] divisao, [5] potencia): ");
            string tipo = Console.ReadLine().ToLower();

            Console.Write("Valor 1: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Valor 2: ");
            double v2 = double.Parse(Console.ReadLine());

            if (!Validar(tipo, v2))
            {
                Console.WriteLine("Operação inválida. Tente novamente.");
                return;
            }

            Operacao op = new Operacao(tipo, v1, v2);
            operacoes.Add(op.Id, op);
            Console.WriteLine($"Resultado: {op.Resultado}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Erro ao adicionar operação: " + e.Message);
        }
    }

    public void Listar()
    {
        if (operacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma operação realizada.");
            return;
        }

        Console.WriteLine("\n Histórico:");
        foreach (var op in operacoes.Values)
        {
            Console.WriteLine(op);
        }
    }

    public void Editar()
    {
        try
        {
            Console.Write("ID da operação a editar: ");
            int id = int.Parse(Console.ReadLine()!);

            if (!operacoes.ContainsKey(id))
            {
                Console.WriteLine("Operação não encontrada.");
                return;
            }

            var op = operacoes[id];

            Console.Write("Novo valor 1: ");
            op.Valor1 = double.Parse(Console.ReadLine()!);

            Console.Write("Novo valor 2: ");
            op.Valor2 = double.Parse(Console.ReadLine()!);

            op.Resultado = op.Calcular();
            Console.WriteLine(" Operação atualizada!");
        }
        catch
        {
            Console.WriteLine(" Operação não encontrada ou erro de entrada.");
        }
    }

    public void Excluir()
    {
        try
        {
            Console.Write("ID da operação a excluir: ");
            int id = int.Parse(Console.ReadLine()!);

            if (operacoes.Remove(id))
                Console.WriteLine(" Operação excluída.");
            else
                Console.WriteLine(" Operação não encontrada.");
        }
        catch
        {
            Console.WriteLine(" Operação não encontrada.");
        }
    }

    private bool Validar(string tipo, double valor2)
    {
        string[] tiposValidos = { "1", "2", "3", "4", "5" };

        if (!tiposValidos.Contains(tipo))
        {
            Console.WriteLine("Tipo de operação inválido. Escolha entre 1 e 5.");
            return false;
        }

        if (tipo == "4" && valor2 == 0)
        {
            Console.WriteLine("Erro: divisão por zero não é permitida.");
            return false;
        }

        return true;

    }
    public void AdicionarTeste(string tipo, double v1, double v2)
    {
        if (!Validar(tipo, v2))
        {
            Console.WriteLine("Operação inválida no teste.");
            return;
        }

        Operacao op = new Operacao(tipo, v1, v2);
        operacoes.Add(op.Id, op);
        Console.WriteLine($"Operação adicionada: {op}");
    }

    public int UltimoId()
    {
        if (operacoes.Count == 0) return -1;
        return operacoes.Keys.Max();
    }

    public void EditarTeste(int id, double novoV1, double novoV2)
    {
        if (!operacoes.ContainsKey(id))
        {
            Console.WriteLine("Operação para editar não encontrada.");
            return;
        }

        Operacao op = operacoes[id];
        op.Valor1 = novoV1;
        op.Valor2 = novoV2;
        op.Resultado = op.Calcular();

        Console.WriteLine($"Operação editada: {op}");
    }

    public void ExcluirTeste(int id)
    {
        if (operacoes.Remove(id))
            Console.WriteLine($"Operação com ID {id} excluída.");
        else
            Console.WriteLine("Operação para excluir não encontrada.");
    }

    public Operacao? BuscarPorId(int id)
    {
        operacoes.TryGetValue(id, out Operacao op);
        return op;
    }

    public Operacao? UltimaOperacao()
    {
        if (operacoes.Count == 0) return null;
        return operacoes.Values.Last();
    }

    public bool ValidarParaTeste(string tipo, double valor2)
    {
        return Validar(tipo, valor2);
    }

    public List<Operacao> ListarParaTeste()
    {
        return operacoes.Values.ToList();
    }




}
    

