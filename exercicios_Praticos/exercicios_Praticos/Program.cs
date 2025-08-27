class Program{
    static void Main(string[] args)
    {
        string alunos;
        for (int i = 0; i < 3; i++)
        {
            System.Console.WriteLine("Entre com o nome do aluno n°"+(i + 1)+":");
            string aluno = Console.ReadLine();
            float soma = 0;
            for (int j = 0; j < 4; j++)
            {
                System.Console.WriteLine("Entre com a nota n° "+(j+1)+" do aluno: "+(aluno));
                int nota = int.Parse(Console.ReadLine());
                soma += nota;
            }
            float media = soma /4;
            System.Console.WriteLine("A media do aluno "+aluno +" é: "+media);
        }
    }
}
