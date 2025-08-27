public class Aluno
{
        string[] Alunos { get; set;}
         float[] Notas{get; set;}
        float[] Media { get; set; }

    List<double> NotasOficiais = new List<double>();


    public void QtdAlunosNotas()
    {
        System.Console.WriteLine("Entre com a qtd de alunos: ");
        int qtdAlunos = int.Parse(Console.ReadLine());
        Alunos = new string[qtdAlunos];
        System.Console.WriteLine("Entre com a qtd de notas: ");
        int qtdnotas = int.Parse(Console.ReadLine());
        Notas = new float[qtdnotas];


    }
    public void Cadastro()
    {
        Media = new float[3];
        
        for (int i = 0; i < Alunos.Length; i++)
        {

            System.Console.WriteLine("Entre com o nome do aluno n° " + (i + 1) + ": ");
            Alunos[i] = Console.ReadLine();
            float soma = 0;

            for (int j = 0; j < Notas.Length; j++)
            {
                System.Console.WriteLine("Digite a nota " + (j + 1) + " do aluno " + Alunos[i] + ": ");
                Notas[j] = float.Parse(Console.ReadLine());
                soma += Notas[j];
            }
            Media[i] = soma / Notas.Length;
            System.Console.WriteLine("A média do aluno " + Alunos[i] + " é: " + Media[i]);
        }

        System.Console.WriteLine("Media dos alunos: ");
        for (int i = 0; i < Alunos.Length; i++)
        {
            System.Console.WriteLine("Aluno: " + Alunos[i] + " Média: " + Media[i]);
        }


    }


    }