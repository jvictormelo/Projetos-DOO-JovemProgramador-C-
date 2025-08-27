using Calculadora.Core;

class Program
{

    static void TestarCenarios()
    {
        Historico historico = new();

        Console.WriteLine("=== Cenário 1: Soma válida ===");
        historico.AdicionarTeste("1", 5, 7);

        Console.WriteLine("\n=== Cenário 2: Divisão por zero inválida ===");
        historico.AdicionarTeste("4", 10, 0);

        Console.WriteLine("\n=== Cenário 3: Editar operação existente ===");
        historico.AdicionarTeste("1", 3, 4); // adiciona operação
        var idParaEditar = historico.UltimoId();
        historico.EditarTeste(idParaEditar, 10, 5);

        Console.WriteLine("\n=== Cenário 4: Excluir operação ===");
        historico.AdicionarTeste("3", 2, 6);
        var idParaExcluir = historico.UltimoId();
        historico.ExcluirTeste(idParaExcluir);

        Console.WriteLine("\n=== Cenário 5: Listar operações ===");
        historico.AdicionarTeste("1", 1, 1);
        historico.AdicionarTeste("5", 2, 3);
        historico.Listar();
    }



    static void Main(string[] args)
    {
        TestarCenarios();
        Historico historico = new();
        int opcao;

        do
        {
            Console.WriteLine("\n--- CALCULADORA ---");
            Console.WriteLine("1 - Nova operação");
            Console.WriteLine("2 - Listar histórico");
            Console.WriteLine("3 - Editar operação");
            Console.WriteLine("4 - Excluir operação");
            Console.WriteLine("5 - Sair");
            Console.Write("Operação Escolhida: ");

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1:
                    historico.Adicionar();
                    break;
                case 2:
                    historico.Listar();
                    break;
                case 3:
                    historico.Editar();
                    break;
                case 4:
                    historico.Excluir();
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
