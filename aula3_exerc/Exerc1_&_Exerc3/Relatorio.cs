public class Relatorio
{
    public static void GerarRelatorio(List<PessoaPagavel> pessoas)
    {
        double total = 0;

        Console.WriteLine("RELATÓRIO DE PAGAMENTO:\n");

        foreach (var pessoa in pessoas)
        {
            double valor = pessoa.CalcularPagamento();
            total += valor;

            if (pessoa is Funcionario funcionario)
            {
                Console.WriteLine($"ID: {funcionario.Id}");
                Console.WriteLine($"CPF: {funcionario.CPF}");
            }

            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Endereço: {pessoa.Endereco}");
            Console.WriteLine($"Pagamento: R$ {valor}");
            Console.WriteLine("----------------------------");
        }

        Console.WriteLine($"Total geral a pagar: R$ {total}");
    }
}
