
class Program
{
    static void Main(string[] args)
    {
        bool rodando = true;

        do
        {
            Console.WriteLine("Deseja começar o controle de caixa? (sim/não)");
            string desejo = Console.ReadLine();

            if (!desejo.Equals("sim", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Console fechando...");
                rodando = false;
            }
            else
            {
                List<float> entradas = new List<float>();
                List<float> saidas = new List<float>();

                while (rodando)
                {
                    Console.WriteLine("\nEscolha uma opção:");
                    Console.WriteLine("1 - Cadastrar entrada");
                    Console.WriteLine("2 - Cadastrar saída");
                    Console.WriteLine("3 - Fechar o controle de caixa");

                    int numero;
                    bool numeroValido = int.TryParse(Console.ReadLine(), out numero);

                    if (!numeroValido)
                    {
                        Console.WriteLine("Entrada inválida! Digite um número.");
                        continue;
                    }

                    switch (numero)
                    {
                        case 1:
                            Console.WriteLine("Entre com o valor de entrada: ");
                            if (float.TryParse(Console.ReadLine(), out float entrada))
                            {
                                entradas.Add(entrada);
                                Console.WriteLine($"Entrada de R$ {entrada} cadastrada.");
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido!");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Entre com o valor de saída: ");
                            if (float.TryParse(Console.ReadLine(), out float saida))
                            {
                                saidas.Add(saida);
                                Console.WriteLine($"Saída de R$ {saida} cadastrada.");
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido!");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Fechando controle de caixa...");
                            float totalEntradas = 0;
                            float totalSaidas = 0;

                            foreach (float e in entradas) totalEntradas += e;
                            foreach (float s in saidas) totalSaidas += s;

                            Console.WriteLine($"Total de entradas: R$ {totalEntradas}");
                            Console.WriteLine($"Total de saídas: R$ {totalSaidas}");
                            Console.WriteLine($"Saldo final: R$ {totalEntradas - totalSaidas}");

                            rodando = false;
                            break;

                        default:
                            Console.WriteLine("Número inválido, tente novamente!");
                            break;
                    }
                }
            }

        } while (rodando);
    }
}