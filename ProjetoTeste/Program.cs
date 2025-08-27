class Program{
    static void Main(string[] args)
    {
        string[] alunos = new string [3];
        float[] notas = new float [4];
        float[] media = new float [3];
        

        for (int i = 0; i <alunos.Length; i++)
        {
            System.Console.WriteLine("Entre com o nome do aluno n° "+(i + 1)+": ");
            alunos[i] = Console.ReadLine();
            float soma = 0;

            for (int j = 0; j < notas.Length; j++)
        {
            System.Console.WriteLine("Digite a nota "+(j + 1)+ " do aluno "+alunos[i]+": ");
            notas[j] = float.Parse(Console.ReadLine());
            soma += notas[j];
        }
        media[i] = soma /notas.Length;
        System.Console.WriteLine("A média do aluno "+alunos[i]+" é: "+media[i]);
        }

        System.Console.WriteLine("Media dos alunos: ");
        for (int i = 0; i <alunos.Length; i++)
        {
            System.Console.WriteLine("Aluno: "+alunos[i]);
            System.Console.WriteLine(" Média: "+media[i]);
        }

    }
}